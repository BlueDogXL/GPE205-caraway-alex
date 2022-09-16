using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIController : Controller
{
    public enum AIStates {Idle, Chase, Attack, Flee, ChooseTarget, Patrol};
    public AIStates currentState;
    public float timeEnteredCurrentState;
    public GameObject AITarget;
    public List<Transform> waypoints;
    public int currentWaypoint;
    // senses data
    public float hearingRadius;
    public float fieldOfView;
    public float viewDistance;
    // Start is called before the first frame update
    public virtual void ChangeState(AIStates newState)
    {
        //remember time we change states
        timeEnteredCurrentState = Time.time;
        //change state
        currentState = newState;
    }
    public virtual void IdleState()
    {
        // do nothing
    }
    public virtual void TargetState()
    {
        AITarget = GetNearestPlayer();
    }
    public virtual GameObject GetNearestPlayer()
    {
        // assume player 0 is closest
        GameObject nearestPlayer = GameManager.instance.players[0].pawn.gameObject;
        float nearestPlayerDistance = Vector3.Distance(pawn.transform.position, GameManager.instance.players[0].pawn.transform.position);
        //now check the rest of the players to see if they are closer
        for (int i = 1; i < GameManager.instance.players.Count; i++)
        {
            float tempDistance = Vector3.Distance(pawn.transform.position, GameManager.instance.players[i].pawn.transform.position);
            if (tempDistance < nearestPlayerDistance)
            {
                nearestPlayer = GameManager.instance.players[i].pawn.gameObject;
                nearestPlayerDistance = tempDistance;
            }
        }
        // we've found the closest player! tell us who they are
        return nearestPlayer;
    } 
    public virtual void ChaseState()
    {
        // TODO: set a max speed for pawns and set the ai's speed to that max

        // Do the chase action
        Chase(AITarget);
    }
    public virtual void ChangeTargetState()
    {
        AITarget = GameManager.instance.players[0].pawn.gameObject;
    }
    public virtual void AttackState()
    {
        pawn.Shoot();
    }
    public virtual void Chase (Transform chaseTarget)
    {
        Chase(chaseTarget.gameObject);
    }
    public virtual void Chase(GameObject chaseTarget)
    {
        if (chaseTarget != null)
        {
            Chase(chaseTarget.transform.position);
        }
        else
        {
            Debug.Log("Chase target was null!");
        }
    }
    public virtual void Chase (Vector3 chaseTarget)
    {
        // turn towards target
        pawn.TurnTowards(chaseTarget);
        // g o  f o r t h
        pawn.MoveForward();
    }
    public virtual bool IsTimePassed(float amountOfTime)
    {
        if (Time.time - timeEnteredCurrentState >= amountOfTime)
        {
            return true;
        }
        return false;
    }
    public virtual void PatrolState()
    {
        //create temp target location
        Vector3 tempTargetLocation = waypoints[currentWaypoint].position;
        //adjust so target y = pawn's y
        tempTargetLocation = new Vector3(tempTargetLocation.x, pawn.transform.position.y, tempTargetLocation.z);
        // move to currentWaypoint
        Chase(tempTargetLocation);
        // if close enough, increment current waypoint
        if (Vector3.Distance(pawn.transform.position, tempTargetLocation) <= 1)
        {
            currentWaypoint++;
        }
        // if at the last waypoint, 
        if (currentWaypoint >= waypoints.Count)
        {
            // go to first waypoint
            currentWaypoint = 0;
        }
        
    } 
    public virtual bool IsCanHear(GameObject target)
    {
        // Get noisemaker component
        NoiseMaker targetNoiseMaker = target.GetComponent<NoiseMaker>();
        // if it doesn't exist then return false. one silent boi
        float sumOfRadii = targetNoiseMaker.noiseDistance + hearingRadius;
        if (targetNoiseMaker == null)
        {
            return false;
        }
        else  
        // if the distance is less than the sum of the two radii then it is heard
        {
            if (Vector3.Distance(target.transform.position, pawn.transform.position) <= sumOfRadii)
            {
                return true;
            }
            else 
            {
                // else return false. they were sneaky enough
                return false;
            }
        }
        
    }
    public virtual bool IsCanSee(GameObject target)
    {
        // check is in field of view
        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
        float angleToTarget = Vector3.Angle(pawn.transform.forward, vectorToTarget);
        if (angleToTarget > fieldOfView)
        {
            return false;
        }
        // check in line of sight
        Ray doYouKnowTheRay = new Ray(pawn.transform.position, vectorToTarget);
        RaycastHit hitInfo;
        if (Physics.Raycast(doYouKnowTheRay, out hitInfo, viewDistance))
        {
            //check if thing hit is target
            if (hitInfo.collider.gameObject == target)
            {
                return true;
            }
        }
        return false;
    }
}
