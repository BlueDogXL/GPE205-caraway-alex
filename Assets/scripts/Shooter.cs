using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public void Shoot(GameObject bulletPrefab, float shootForce, float damage, Pawn shooter, Transform shootPoint)
    {
        //create bullet
        GameObject theBullet = Instantiate(bulletPrefab, shootPoint.position, transform.rotation);

        //give it data
        Projectile projectile = theBullet.GetComponent<Projectile>();

        if (projectile != null) 
        {
            projectile.damage = damage;
            projectile.owner = shooter;
        }
        //watch it fly
        Rigidbody bulletRb = theBullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.AddForce(transform.forward * shootForce);
        }
        Destroy(theBullet, 5);
    }
}
