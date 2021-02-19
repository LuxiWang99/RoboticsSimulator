using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorControl : MonoBehaviour
{
    public Rigidbody block;
    public GameObject floor;

    private List<Vector3> tags = new List<Vector3>();

    public GameObject Post;
    public GameObject Gate;
    void Start()
    {
        AddDefaultObstacles();
         
    }


    void AddObstacle(Vector3 vec)
    {
        Instantiate(block, vec, Quaternion.identity);
    }


    void AddDefaultObstacles()
    {
        Instantiate(block, new Vector3(-4f, 4f, 4f), Quaternion.identity);
        Instantiate(block, new Vector3(-5f, 5f, 5f), Quaternion.identity);
        Instantiate(block, new Vector3(-1f, 1f, 1f), Quaternion.identity);
    }

    // Transform readTrueTransform()
     // {
     //     
     // }


     // List<Vector3> readLandmarks(Transform current_transform_truth) { 
     //     List<Vector3> res = new List<Vector3>();
     //    Vector3 robot_location = current_transform_truth.position;
     //    foreach (Vector3 lm in tags) {
     //        Vector3 reading = Vector3.Dot(current_transform_truth, lm);
     //        float dist = (robot_location - lm).magnitude;
     //        corrupt(reading, dist);
     //        float t = obstacleIntersection(robot_location, lm, obstacles_);
     //
     //        if (dist > LANDMARK_MAX_RANGE || t < 0.999999) {
     //            readoing *= 0;
     //        }
     //        res.Add(reading);
     //    }
     //    return res;
     // }

     // void corrupt(Vector3 point, float dist) {
     //     
     // }



    // Update is called once per frame
    // void Update()
    // {
        
    // }

}
