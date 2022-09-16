using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public List<Powerup> powerups;
    // Start is called before the first frame update
    void Start()
    {
        // create list of powerups
        powerups = new List<Powerup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Apply(Powerup powerupToApply)
    {
        powerupToApply.Apply(this);
        powerups.Add(powerupToApply);
    }
    public void Remove(Powerup powerupToRemove)
    {
        // TODO: also make this a thing
        powerupToRemove.Remove(this);
        powerups.Remove(powerupToRemove);
    }
}
