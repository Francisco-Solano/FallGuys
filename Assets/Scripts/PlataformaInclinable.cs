using UnityEngine;

public class PlatformInclinable : MonoBehaviour
{
    public Transform centroDeMasa; // This will be the object that the platform is attached to
    public float inclinationMaximum = 45f; // The maximum inclination of the platform
    public float velocityRotation = 1.5f; // The speed at which the platform rotates to return to its original position

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centroDeMasa.localPosition;

        // Comment out the line that is moving the attachment point of the platform
        rb.transform.position += new Vector3(0, 0, centroDeMasa.transform.localPosition.z - rb.transform.localScale.z / 2);
    }

    void FixedUpdate()
    {
        if (EstaInclinada())
        {
            // Calculate the angle of inclination of the platform
            float angle = Mathf.Atan2(rb.transform.position.y - centroDeMasa.transform.position.y, rb.transform.position.x - centroDeMasa.transform.position.x);

            // Check if the angle of inclination is greater than the maximum allowed
            if (angle > inclinationMaximum)
            {
                // If the angle of inclination is greater than the maximum allowed, rotate the platform to return it to its original position
                rb.AddTorque(new Vector3(0, 0, -angle * velocityRotation));
            }
        }
    }

    bool EstaInclinada()
    {
        // Check if the platform is inclined
        return Mathf.Abs(rb.rotation.eulerAngles.z) > inclinationMaximum;
    }
}
