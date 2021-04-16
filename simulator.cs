using UnityEditor;
using System.Diagnostics;
using System;
using System.IO;

public class ScriptBatch 
{

   [ComVisible(true)]
   public static void testing()
   {
     Console.WriteLine("This is from C#");
   }

    // works as void world_interface_init() from the old simulator.
    // https://github.com/huskyroboticsteam/PY2020/blob/3d-simulator-world-interface/src/Networking/simulator_3D_world_interface.cpp
    [MenuItem("MyTools/Windows Build With Postprocess")]
    public static void BuildGame ()
    {
        // Get filename.
        string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string[] levels = new string[] {"Assets/MainScene.unity", "Assets/MissionControl.unity"};

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
    {}

    public Tuple<double, double, double>[] readLidarScan()
    {
      // return Tuple.Create(0.0,0.0,0.0);
      return null;
    }

    public Tuple<double, double, double>[] readLandmarks()
    {
      return null;
    }

    public Matrix readGPS()
    {

    }

}
