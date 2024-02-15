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
            // Set the velocity directly to achieve instant speed
            rb.velocity = transform.forward * bloodBallSpeed;
        }
        else
        {
            Debug.LogError("Rigidbody not found on BloodBallForce!");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            Destroy(gameObject);
            Debug.Log("BloodBall Destroyed");
        }

        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
            Debug.Log("BloodBall Destroyed");
        }
    }
}
