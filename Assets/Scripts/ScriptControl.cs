using UnityEngine;
using System;

public class ScriptControl : MonoBehaviour
{
    public Rover rover;


    private void Start()
    {
    }


    public bool setCmdVel(double dtheta, double dx)
    {
        rover.SetVelocity(dx, dtheta);
        return true;
    }

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