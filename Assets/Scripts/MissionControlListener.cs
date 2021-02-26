using UnityEngine;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Text;

/// <summary>
/// Connects to the Mission Control server and listens for requests.
/// </summary>
public class MissionControlListener : MonoBehaviour
{
    public Rover rover;

    private bool listen;

    private void Start()
    {
        // We must connect on a separate thread so that the simulator can
        // continue running in parallel.
        listen = true;
        Thread thread = new Thread(Connect);
        thread.Start();
    }

    private void OnDestroy()
    {
        listen = false;
    }

    /// <summary>
    /// Creates a connection to the mission control server.
    /// </summary>
    private void Connect()
    {
        TcpClient client = new TcpClient("localhost", 3001);
        StreamReader reader = new StreamReader(client.GetStream());

        StringBuilder jsonBuilder = new StringBuilder();
        int openBraceCount = 0;
        int firstBraceIndex = -1;
        while (listen)
        {
            char ch = (char)reader.Read();
            if (ch == '{')
            {
                if (firstBraceIndex == -1)
                {
                    firstBraceIndex = jsonBuilder.Length;
                }
                openBraceCount++;
            }
            else if (ch == '}')
            {
                openBraceCount--;
            }

            jsonBuilder.Append(ch);
            if (firstBraceIndex != -1 && openBraceCount == 0)
            {
                // end of request
                string request = jsonBuilder.ToString().Substring(firstBraceIndex);
                ProcessRequest(request);

                jsonBuilder = new StringBuilder();
                firstBraceIndex = -1;
            }
        }
        Debug.Log("Closing connection to Base Station");
        reader.Close();
        client.Close();
    }

    /// <summary>
    /// Processes the given json request.
    /// </summary>
    /// <param name="request">the json request in string format</param>
    private void ProcessRequest(string request)
    {
        int typeStartIndex = request.IndexOf("type") + 7;
        int typeEndIndex = request.Substring(typeStartIndex).IndexOf("\"");
        string type = request.Substring(typeStartIndex, typeEndIndex);
        switch (type)
        {
            case "drive":
                DriveRequest driveRequest = JsonUtility.FromJson<DriveRequest>(request);
                rover.SetVelocity(driveRequest.forward_backward, driveRequest.left_right);
                break;
            case "estop":
                EStopRequest eStopRequest = JsonUtility.FromJson<EStopRequest>(request);
                rover.EStop(eStopRequest.release);
                break;
            case "motor":
                Debug.LogError("Motor request type not yet supported");
                break;
            default:
                Debug.LogError("Unknown request type: " + request);
                break;
        }
    }

    [System.Serializable]
    private struct DriveRequest
    {
        public string type;
        public float forward_backward;
        public float left_right;
    }

    [System.Serializable]
    private struct MotorRequest
    {
        public string type;
        public string motor;
        public string mode;
        public float PID_target;
    }

    [System.Serializable]
    private struct EStopRequest
    {
        public string type;
        public bool release;
    }
}
