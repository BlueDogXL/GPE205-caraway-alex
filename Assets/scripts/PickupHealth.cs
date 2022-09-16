using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : MonoBehaviour
{
    PowerupHeal powerup;
    public void OnTriggerEnter(Collider other)
    {
        PowerupManager otherPowerupManager = other.GetComponent<PowerupManager>();
        if (otherPowerupManager != null)
        {
            otherPowerupManager.Apply(powerup);
            Destroy(gameObject);
        }
    }
}
