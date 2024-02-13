using System;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static EventHandler Instance;

    // Event to notify when a card is picked up
    public Action OnCardPickup = delegate { };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // No need for the else part
    }

    // Trigger this method to notify all subscribers that a card is picked up
    public void PickupCard()
    {
        Debug.Log("Card picked up!");
        OnCardPickup?.Invoke();
    }
}
