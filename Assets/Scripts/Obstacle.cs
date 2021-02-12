using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Obstacle : MonoBehaviour
    {
        private void Start()
        {
            gameObject.tag = "Obstacle";
        }
    }
}