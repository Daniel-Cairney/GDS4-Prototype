using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBallAbility : MonoBehaviour
{
    public GameObject bloodBallPrefab; // Assign the Blood Ball prefab in the Inspector
    public Transform spawnPoint; // Assign the spawn point in the Inspector
    public float bloodBallSpeed = 10f;

    // Reference to the orientation from the PlayerMovement script
    public Transform orientation;

    private void Start()
    {
        // Subscribe to the event when a charge is used
        EventHandler.Instance.OnChargeUsed += UseBloodBallAbility;

        Debug.Log("BloodBallAbility script started.");
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event when the script is destroyed
        EventHandler.Instance.OnChargeUsed -= UseBloodBallAbility;

        Debug.Log("BloodBallAbility script destroyed.");
    }

    private void UseBloodBallAbility()
    {
        if (CanUseBloodBall()) // Check if conditions for using the ability are met
        {
            // Instantiate the Blood Ball at the spawn point
            GameObject bloodBall = Instantiate(bloodBallPrefab, spawnPoint.position, spawnPoint.rotation);

            if (bloodBall != null)
            {
                // Get the Rigidbody of the Blood Ball
                Rigidbody bloodBallRb = bloodBall.GetComponent<Rigidbody>();

                if (bloodBallRb != null)
                {
                    // Apply force to the Blood Ball in the direction the player is looking
                    bloodBallRb.velocity = orientation.forward * bloodBallSpeed;

                    // Add any additional logic for the Blood Ball here
                    Debug.Log("Blood Ball instantiated and moving.");
                }
                else
                {
                    Debug.LogError("Blood Ball Rigidbody not found!");
                }
            }
            else
            {
                Debug.LogError("Blood Ball GameObject not instantiated!");
            }
        }
        else
        {
            Debug.LogWarning("Cannot use Blood Ball ability.");
        }
    }

    private bool CanUseBloodBall()
    {
        // Add any conditions that need to be met to use the Blood Ball ability
        return true; // For now, always return true to use the ability
    }
}
