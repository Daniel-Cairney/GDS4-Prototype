using System;
using UnityEngine;

public class CardPickup : MonoBehaviour
{
    // Event triggered when a card is picked up
    public static event Action OnCardPickedUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger zone");

            // Trigger the event when a card is picked up
            OnCardPickedUp?.Invoke();

            Destroy(gameObject);
        }
    }
}
