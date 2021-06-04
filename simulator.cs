using UnityEditor;
using System.Diagnostics;
using System;
using System.IO;
using ScriptControl;
using System.Threading;
using System.Linq;

public class ScriptBatch
{

    bool listen = false;

    public const int BUFFER = 256;

    [ComVisible(true)]
    public static void testing()
    {
        Console.WriteLine("This is from C#");
    }

    // works as void world_interface_init() from the old simulator.
    // https://github.com/huskyroboticsteam/PY2020/blob/3d-simulator-world-interface/src/Networking/simulator_3D_world_interface.cpp
    [MenuItem("MyTools/Windows Build With Postprocess")]
    public static void BuildGame()
    {
        // Get filename.
        string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string[] levels = new string[] { "Assets/MainScene.unity", "Assets/MissionControl.unity" };

        // Build player.
        BuildPipeline.BuildPlayer(levels, path + "/simulator.app", BuildTarget.StandaloneWindows, BuildOptions.None);

        //// Copy a file from the project folder to the build folder, alongside the built game.
        //FileUtil.CopyFileOrDirectory("Assets/Templates/Readme.txt", path + "Readme.txt");

        // Run the game (Process class from System.Diagnostics).
        Process proc = new Process();
        proc.StartInfo.FileName = path + "/simulator.app";
        proc.Start();
    }

    public bool setCmdVel(double dtheta, double dx)
    {
        return ScriptControl.setCmdVel(dtheta, dx);
    }

    public double noiseGeneration(double std)
    {
        Random rand = new Random();
        double u1 = 1.0 - rand.NextDouble();
        double u2 = 1.0 - rand.NextDouble();

        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
        return std * randStdNormal;
    }

    public void Start()
    {
        listen = true;
        Thread thread = new Thread(Connect);
        thread.Start();
    }

    // Connect to the Unity Simulator.
    // req: The server only recognize "Lidar", "GPS", "Landmark", it should return the Lidar readings in
    // String if "Lidar" is passed through this function. Similar in the "GPS" case.
    public string Connect(String req)
    {
        TcpClient client = new TcpClient("localhost", 13000);
        // StreamReader reader = new StreamReadser(client.GetStream());
        NetworkStream netStream = client.GetStream();
        Console.WriteLine("Connection is successful");
        Byte[] request = Encoding.UTF8.GetBytes(req);
        netStream.Write(requeset, 0, bytes.Length);


        Byte[] response = new byte[BUFFER];
        string readings = String.Empty;

        Int32 r = Stream.Read(response, 0, response.Length);
        readings = System.Text.Encoding.ASCII.GetString(response, 0, r);
        Console.WriteLine("Received: {0}", readings);

        client.close();
        netStream.close();
        return readings;
    }

    string[] parseStringArray(String s)
    {
        string[] split = s.Split(new char[] { '*' });
        return split;
    }


    Vector3 parseVector3(String s)
    {
        Vector3 res;
        string[] splits0 = s.Split(new char[] { '(', ')' });
        string[] splits = splits0[1].Split(new char[] { ',' });
        //string[] splits2=splits[0].Split(new char[]{'!'});
        float x = float.Parse(splits[0]);
        float y = float.Parse(splits[1]);
        float z = float.Parse(splits[2]);
        res = new Vector3(x, y, z);
        return res;
    }

    public Vector3<double, double, double>[] readLidarScan()
    {

        string[] r = parseStringArray(Connect("Lidar"));
        Vector3[] lidarReading = r.Select(x => parseVector3(x));

        int i;
        for (i = 0; i < lidarReading.Length; ++i)
        {
            // 2 is an arbitrarily chosen std
            lidarReading[i][0] += noiseGeneration(2);
            lidarReading[i][1] += noiseGeneration(2);
        }

        return lidarReading;
    }


    // We should implement either this method (a list of locations of AR
    // tags relative to the camera on the rover) or a new method that
    // returns an image captured by the camera.
    //
    // For this method, the index of the point_t in the list corresponds to
    // the ID of that AR tag. If we can't see an AR tag (too far, or behind
    // an obstacle) we should return (0,0,0) at that index in the list.
    public Tuple<double, double, double>[] readLandmarks()
    {

        // 
        return null;
    }

    public Vector3 readGPS()
    {
        Vector3 position = parseVector3(Connect("GPS"));

        position[0] += noiseGeneration(2);
        position[1] += noiseGeneration(2);

        return position;
    }

}
