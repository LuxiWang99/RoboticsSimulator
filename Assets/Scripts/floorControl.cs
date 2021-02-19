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
         // addDefaultObstacles();
         Instantiate(block, new Vector3(-4f, 4f, 4f), Quaternion.identity);
         Instantiate(block, new Vector3(-5f, 5f, 5f), Quaternion.identity);
         Instantiate(block, new Vector3(-1f, 1f, 1f), Quaternion.identity);
    }


    void addObstacle(float x, float y)
    {
        Instantiate(block, new Vector3(x,0.0f,y), Quaternion.identity);
    }


    void addDefaultObstacles()
    {
        addObstacle(1.7f, 2.2f);
        addObstacle(3.1f, 7.6f);
        addObstacle(4.7f, 4.1f);
    }

    int addLandmark(float x, float y) { // equivalent of addLandmark
        Vector3 vec = new Vector3(x, y, 0f);
        tags.Add(vec);
        return tags.Count - 1;
    }

    void addPost(float x, float y, float gpsX, float gpsY){
        if (legs_.Count == 7)
        {
            return; // the max number is legs should be 7
        }
        var id = addLandmark(x, y);
        Leg l = new Leg(id, -1, (gpsX, gpsY, 1));
        legs_.Add(l);
        Instantiate(Post, new Vector3(x, 0.0f, y), Quaternion.identity);
    }

     void addGate(float x, float y, double theta, double width, float gpsX, float gpsY){
         if (legs_.Count == 7)
         {
             return; // the max number is legs should be 7
         }
        var x1 = x + Math.Sin(theta)*width/2;
        var y1 = y - Math.Cos(theta)*width/2;
        var x2 = x - Math.Sin(theta)*width/2;
        var y2 = y + Math.Cos(theta)*width/2;
        Instantiate(Gate, new Vector3(x,0.0f,y), Quaternion.identity);
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

     Leg getLeg(int index)
     {
         if (index < 0 || index >= legs_.Count - 1)
         {
             return new Leg(-1, -1, (0, 0, 0));
         }

         return legs_[index];
     }

     void corrupt(Vector3 point, float dist) {
         
     }



    // Update is called once per frame
    // void Update()
    // {
        
    // }

}
