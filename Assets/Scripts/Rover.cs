using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Rover : MonoBehaviour
    {
        void Start()
        {
            transform.rotation = Random.rotation; // Randomly spin the rover to start
            transform.position = new Vector3(0, 0);
        }
        private void OnCollisionEnter(Collider other)
        {
            if (other.tag == "Obstacle")
            {
                Debug.Log("");
            }
        }
    }
    
    

}