using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BloodBall"))
        {
            Destroy(gameObject);
            Debug.Log("Wall Destroyed");
        }
    }

}
