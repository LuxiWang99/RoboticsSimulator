using UnityEngine;

/// <summary>
/// Allows a user to control a rover using WASD controls.
/// </summary>
public class RoverController : MonoBehaviour
{
    public Rover rover;

    private void Update()
    {
        float forwardBackward = Input.GetAxis("Vertical");
        float leftRight = Input.GetAxis("Horizontal");
        rover.setVelocity(forwardBackward, leftRight);
    }
}
