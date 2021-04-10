using UnityEngine;

public class RoverCamera : MonoBehaviour
{
    public GameObject rover;
    public Vector3 offset;

    private void Update()
    {
        transform.position = rover.transform.position + offset;
    }
}
