using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : Controller
{
    public KeyCode moveForward;
    public KeyCode moveBackward;
    public KeyCode turnRight;
    public KeyCode turnLeft;
    public KeyCode shoot;
    // Start is called before the first frame update
    public override void Start()
    {
        // add myself to list
        if (GameManager.instance != null)
        {
            if(GameManager.instance.players != null)
            {
                GameManager.instance.players.Add(this);
                Debug.Log("Player Controller Added");
            }
        }
        
    }

    // Update is called once per frame
    public override void Update()
    {
        MakeDecisions();
    }
    public void OnDestroy()
    {
        GameManager.instance.players.Remove(this);
    }

    public override void MakeDecisions()
    {
        if (Input.GetKey(moveForward))
        {
            pawn.MoveForward();
            Debug.Log("Up!");
        }
        if (Input.GetKey(moveBackward))
        {
            pawn.MoveBackward();
            Debug.Log("Down!");
        }
        if (Input.GetKey(turnRight))
        {
            pawn.TurnRight();
            Debug.Log("Right!");
        }
        if (Input.GetKey(turnLeft))
        {
            pawn.TurnLeft();
            Debug.Log("Left!");
        }
        if (Input.GetKeyDown(shoot))
        {
            pawn.Shoot();
            Debug.Log("Chu!");
        }
    }
}
