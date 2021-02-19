using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorControl : MonoBehaviour
{
    public GameObject Block;
    public GameObject floor;
    public GameObject Post;
    public GameObject Gate;
    public GameObject Tag;
    void Start()
    {
        // AddDefaultObstacles();
        Gate.transform.localScale = new Vector3(5, 5, 5);
        
        Instantiate(Gate, new Vector3(5f, 5f, 5f), Quaternion.identity).transform.Rotate(90,0,0, Space.Self);
        // Tag.transform.Rotate(90,0,0, Space.Self);
        // Post.transform.Rotate(90,0,0, Space.Self);
    }
    
    public void AddPost(Vector3 vec)
    {
        GameObject p = Instantiate(Post, vec, Quaternion.identity);
        p.transform.Rotate(90, 0, 0, Space.Self);
        p.tag = "Post";
    }

    public void AddARTag(Vector3 vec)
    {
        GameObject p = Instantiate(Tag, vec, Quaternion.identity);
        p.transform.Rotate(90, 0, 0, Space.Self);
        p.tag = "Tag";
    }

    public void AddGate(Vector3 vec)
    {
        GameObject p = Instantiate(Gate, vec, Quaternion.identity);
        p.transform.Rotate(90, 0, 0, Space.Self);
        p.tag = "Gate";
    }


    public void AddObstacle(Vector3 vec)
    {
        GameObject p = Instantiate(Block, vec, Quaternion.identity);
        p.tag = "Obstacle";
    }


    void AddDefaultObstacles()
    {
        AddObstacle(new Vector3(-4f, 4f, 4f));
        AddObstacle(new Vector3(-5f, 5f, 5f));
        AddObstacle(new Vector3(-1f, 1f, 1f));
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
