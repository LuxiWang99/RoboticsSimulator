using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Rover : MonoBehaviour
    {
        public GameObject robot;
        void Start()
        {
            robot.transform.rotation = Random.rotation; // Randomly spin the rover to start
            float x = 90;
            if (Random.value < 0.5)
            {
                x = 0;
            }

            robot.transform.position = new Vector3(x, -3);
        }
    }
}