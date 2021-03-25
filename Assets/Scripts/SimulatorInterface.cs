using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private static Rover rover;

    public static void WorldInterfaceInit()
    {
        rover = GameObject.Find("Rover").GetComponent<Rover>();
    }

    public static void SetCmdVel(float dTheta, float dx)
    {
        rover.SetVelocity(dx, dTheta);
    }

    public static Vector3[] ReadLidarScan()
    {
        Vector3[] scan = rover.LidarScan();
        return scan;
    }

    public static Vector3[] ReadLandmarks()
    {
        return null;
    }

    public static Transform ReadGPS()
    {
        return rover.transform;
    }
}
