using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject block;
    void Start()
    {
         addDefaultObstacles();
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
    // int addLandmark();

    // void addPost();

    // void addGate();

    // not sure what Landmark, Post and Gate are. Will implement once it is figured out. 


    // Update is called once per frame
    // void Update()
    // {
        
    // }

}
