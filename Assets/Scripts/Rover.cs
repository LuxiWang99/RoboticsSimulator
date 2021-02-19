using UnityEngine;

/// <summary>
/// Main component of the rover GameObject.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Rover : MonoBehaviour
{
    public float linearSpeed;
    public float rotationSpeed;

    private Rigidbody rb;
    private float driveforwardBackward;
    private float driveLeftRight;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        driveforwardBackward = 0.0f;
        driveLeftRight = 0.0f;
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * driveforwardBackward;
        rb.angularVelocity = new Vector3(0.0f, -driveLeftRight, 0.0f);
        // prevent obstacles from forcing unwanted transformations on rover
        Vector3 pos = transform.position;
        pos.y = 0.0f;
        transform.position = pos;
        transform.rotation = Quaternion.Euler(0.0f, transform.rotation.eulerAngles.y, 0.0f);
    }

    /// <summary>
    /// Sets the velocity of the rover.
    /// </summary>
    /// <param name="forwardBackward">The linear velocity [-1.0, 1.0]. Positive values correspond to forward motion. Negative values correspond to backward motion.</param>
    /// <param name="leftRight">The rotational velocity [-1.0, 1.0]. Positive values correspond to counterclockwise rotation. Negative values correspond to clockwise rotation.</param>
    public void SetVelocity(float forwardBackward, float leftRight)
    {
        this.driveforwardBackward = forwardBackward * linearSpeed;
        this.driveLeftRight = leftRight * rotationSpeed;
    }

    public void EStop(bool release)
    {
        Debug.LogError("EStop not yet supported");
    }
}
