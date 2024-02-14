using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackManager : MonoBehaviour
{
    [SerializeField] private List<Image> cardUIStack;
    [SerializeField] private int chargeCount = 0;
    private int maxStackCount = 3;

    [SerializeField] private GameObject bloodBallPrefab; // Assign the Blood Ball prefab in the Inspector
    [SerializeField] private Transform spawnPoint; // Assign the spawn point in the Inspector

    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private Transform platformSpawnPoint;
    private void Start()
    {
        // Disable all UI images at the beginning
        foreach (Image cardImage in cardUIStack)
        {
            cardImage.enabled = false;
        }
    }

    private void OnEnable()
    {
        // Subscribe to the event when this script is enabled
        CardPickup.OnCardPickedUp += HandleCardPickup;
    }

    private void OnDisable()
    {
        // Unsubscribe from the event when this script is disabled
        CardPickup.OnCardPickedUp -= HandleCardPickup;
    }

    private void HandleCardPickup()
    {
        Debug.Log("Handling card pickup!"); // Add this debug log
        if (chargeCount < maxStackCount)
        {
            chargeCount++;

            // Enable the corresponding UI image
            if (chargeCount <= cardUIStack.Count)
            {
                Image cardImage = cardUIStack[chargeCount - 1];
                if (cardImage != null && !cardImage.enabled)
                {
                    Debug.Log("UI Card on");
                    cardImage.enabled = true;
                }
            }
        }
        else
        {
            Debug.Log("Max charges reached.");
        }
    }

    private void Update()
    {
        // Check for left-click input
        if (Input.GetMouseButtonDown(0))
        {
            // Consume a charge if there are charges available
            if (chargeCount > 0)
            {
                chargeCount--;

                // Disable the corresponding UI image
                if (chargeCount < cardUIStack.Count)
                {
                    Image cardImage = cardUIStack[chargeCount];
                    if (cardImage != null && cardImage.enabled)
                    {
                        Debug.Log("UI Card off");
                        cardImage.enabled = false;

                        UseBloodBall();
                    }
                }
            }
            else
            {
                Debug.Log("No charges available.");
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            // Consume a charge if there are charges available
            if (chargeCount > 0)
            {
                chargeCount--;

                // Disable the corresponding UI image
                if (chargeCount < cardUIStack.Count)
                {
                    Image cardImage = cardUIStack[chargeCount];
                    if (cardImage != null && cardImage.enabled)
                    {
                        Debug.Log("UI Card off");
                        cardImage.enabled = false;

                        Debug.Log("Rigt click detected");
                        PlaceAblePlatform();
                    }
                }
            }
            else
            {
                Debug.Log("No charges available.");
            }
        }
    }
    private void UseBloodBall()
    {
        // Instantiate the Blood Ball at the spawn point
        Instantiate(bloodBallPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    private void PlaceAblePlatform()
    {
        Instantiate(platformPrefab, platformSpawnPoint.position, platformSpawnPoint.rotation);
    }
}
