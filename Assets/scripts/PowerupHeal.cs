using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerupHeal : Powerup
{
    public float healingAmount;
    public override void Apply(PowerupManager target)
    {
        GameObject targetObject = target.gameObject;
        Health targetHealth = targetObject.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.HealDamage(healingAmount); 
        }
    }

    public override void Remove(PowerupManager target)
    {
        throw new System.NotImplementedException();
    }
}
