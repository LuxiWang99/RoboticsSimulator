using UnityEngine;

public class RoverCamera : MonoBehaviour
{
    public GameObject rover;
    public float height;

    private void Update()
    {
        transform.position = rover.transform.position + new Vector3(0.0f, height, 0.0f);
    }
}
