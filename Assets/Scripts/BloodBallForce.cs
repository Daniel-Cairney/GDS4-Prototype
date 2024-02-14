using UnityEngine;

public class BloodBallForce : MonoBehaviour
{
    public float bloodBallSpeed = 10f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody not found on BloodBallForce!");
        }
    }

    private void FixedUpdate()
    {
        ApplyConstantForce();
    }

    private void ApplyConstantForce()
    {
        if (rb != null)
        {
            // Apply constant force in the forward direction
            rb.AddForce(transform.forward * bloodBallSpeed, ForceMode.Force);
        }
        else
        {
            Debug.LogError("Rigidbody not found on BloodBallForce!");
        }
    }
}
