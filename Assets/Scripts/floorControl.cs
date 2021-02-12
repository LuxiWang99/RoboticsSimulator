using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorControl : MonoBehaviour
{
    public struct Leg
    {
        public Leg(int left, int right, (float, float, float) gps)
        {
            left_post_id = left;
            right_post_id = right;
            approx_GPS = gps;
        }
        public int left_post_id;
        public int right_post_id;
        public (float, float, float) approx_GPS;
    }

    private List<Leg> legs_ = new List<Leg>();
    private List<Vector3> tags = new List<Vector3>();

    public GameObject Block;
    public GameObject Post;
    public GameObject Gate;
    void Start()
    {
         addDefaultObstacles();
    }


    void addObstacle(float x, float y)
    {
        Instantiate(Block, new Vector3(x,0.0f,y), Quaternion.identity);
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
        var right_id = addLandmark((float)x1, (float)y1);
        var left_id = addLandmark((float)x2, (float)y2);
        Leg l = new Leg(left_id, right_id, (gpsX, gpsY, 1));
        legs_.Add(l);
        Instantiate(Gate, new Vector3(x,0.0f,y), Quaternion.identity);
     }

     Transform readTrueTransform()
     {
         return 
     }


     List<Vector3> readLandmarks(Transform current_transform_truth) { 
         List<Vector3> res = new List<Vector3>();
        Vector3 robot_location = current_transform_truth.position;
        foreach (Vector3 lm in tags) {
            Vector3 reading = Vector3.Dot(current_transform_truth, lm);
            float dist = (robot_location - lm).magnitude;
            corrupt(reading, dist);
            float t = obstacleIntersection(robot_location, lm, obstacles_);

            if (dist > LANDMARK_MAX_RANGE || t < 0.999999) {
                readoing *= 0;
            }
            res.Add(reading);
        }
        return res;
     }

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
