using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    protected Mover mover;
    public float turnSpeed;
    public float moveSpeed;
    // Start is called before the first frame update
    public virtual void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {

    }
    public virtual void MoveForward()
    {
        mover.MoveForward(moveSpeed);
    }
    public virtual void MoveBackward()
    {
        mover.MoveForward(-moveSpeed);
    }
    public virtual void TurnRight()
    {
        mover.Turn(turnSpeed);
    }
    public virtual void TurnLeft()
    {
        mover.Turn(-turnSpeed);
    }
    public virtual void TurnTowards(Vector3 targetPosition)
    {

    }
    public virtual void Shoot()
    {

    }
}
