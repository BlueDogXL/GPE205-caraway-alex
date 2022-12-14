using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : Mover
{
    private Rigidbody rigidbodyComponent;
    // Start is called before the first frame update
    void Start()
    {
        //load components into variables
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void MoveForward(float speed)
    {
        rigidbodyComponent.MovePosition(transform.position + (transform.forward * speed * Time.deltaTime));
    }
    public override void Turn(float speed) // turns the tank
    {
        transform.Rotate(0, speed, 0);
    }
}
