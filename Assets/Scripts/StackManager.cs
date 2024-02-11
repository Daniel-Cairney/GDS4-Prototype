using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackManager : MonoBehaviour
{
    [SerializeField] private List<Image> cardUIStack;
    [SerializeField] private int chargeCount = 0;
    private int maxStackCount = 3;

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
        EventHandler.Instance.OnCardPickup += HandleCardPickup;
    }

    private void OnDisable()
    {
        // Unsubscribe from the event when this script is disabled
        EventHandler.Instance.OnCardPickup -= HandleCardPickup;
    }


    private void HandleCardPickup()
    {
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
                    }
                }
            }
            else
            {
                Debug.Log("No charges available.");
            }
        }
    }
}
