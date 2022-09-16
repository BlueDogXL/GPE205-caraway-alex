using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    public Shooter shooter;
    public GameObject bulletPrefab;
    public float damage;
    public float shootForce;
    public Transform shootPoint;
    private float nextShootTime;
    public float timeBetweenShots;

    // Start is called before the first frame update
    public override void Start()
    {
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();

        nextShootTime = Time.time + timeBetweenShots;
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public override void Shoot()
    {
        if (Time.time >= nextShootTime)
        {
            shooter.Shoot(bulletPrefab, shootForce, damage, this, shootPoint);
            nextShootTime = Time.time + timeBetweenShots;
        }
    }

    public override void MoveForward()
    {
        base.MoveForward();
    }
    public override void MoveBackward()
    {
        base.MoveBackward();
    }
    public override void TurnRight()
    {
        base.TurnRight();
    }
    public override void TurnLeft()
    {
        base.TurnLeft();
    }
    public override void TurnTowards(Vector3 targetPosition)
    {
        // find the vector to target position
        Vector3 vectorToTargetPosition = targetPosition - transform.position;
        // find the quaternion to look down that vector
        Quaternion look = Quaternion.LookRotation(vectorToTargetPosition, transform.up);
        // change our rotation to be slightly down that quaternion
        transform.rotation = Quaternion.RotateTowards(transform.rotation, look, turnSpeed);
    }
}
