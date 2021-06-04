using UnityEngine;

public class LidarUsage : MonoBehaviour
{
    public Rover rover;
    public string[] lidarReadings;
    public const int BUFFER = 256;

    public const int num_beams = 4000;

    private void Start()
    {
        Thread thread = new Thread(Connect);
        thread.Start();
    }

    private void Connect()
    {
        TcpListener server = null;
        try
        {
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            server = new TcpServer();

            server.Start();
            byte[] bytes = new byte[BUFFER];

            // uses "*" as seperation, since the vectors are in the form of (x,y,z), in which "," is already used.
            string lidarData = String.Join("*", lidarReadings);

            while (true)
            {
                Debug.log("Waiting for a connection...");


                TcpClient client = server.AcceptTcpClient();

                NetworkStream stream = client.GetStream();

                int i;
                string req;
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    req = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    byte[] msg;

                    if (req.Equals("Lidar"))
                    {
                        msg = System.Text.Encoding.ASCII.GetBytes(lidarData);
                        stream.Write(msg, 0, msg.Length);
                    }
                    else if (req.Equals("GPS"))
                    {
                      msg = System.Text.ASCII.GetBytes(rover.transform.position.toString()); // ?? this may not be correct
                    }
                }
            }
            // Close everything.
            stream.Close();
            client.Close();
        }
        catch (Exception e)
        {
            Debug.Log("Exception: {0}, retyring in 3 seconds.", e);
            Thread.Sleep(3000);
            Connect();
        }
    }

    void FixedUpdate()

    {
        RaycastHit hit;

        // clear the previous readings
        Array.Clear(lidarReadings, 0, lidarReadings.length);

        Vector3 startingAngle = new Vector3(-1, 0, Mathf.Sqrt(3));
        float toRotate = 240 / num_beams; // the actual lidar read 240 degrees
        for (int i = 0; i < num_beams; i++)
        {
            bool rayRes = Physics.Raycast(rover.transform.position, transform.TransformDirection(startingAngle * Quaternion.Euler(0, i * toRotate, 0), out hit, Mathf.Infinity));
            if (rayRes)
            {
                // currently, we only worry about 2D case. And therefore set z = 1.0
                // Note, in Unity, z (positive) is the front direction. x (positive) the right
                // direction.
                // Technically, we should set the y direction to be the height.
                Vector3 vec = new Vector3(hit.transform.position[0], hit.transform.position[2], 1.0);
                lidarReadings.Add(vec.ToString());
            }
        }
    }
}