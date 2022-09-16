using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControllerAggressive : AIController
{
    // Start is called before the first frame update
    public override void Start()
    {
        //TODO: player doesn't exist when ai starts. fix that :<
       ChangeState(AIStates.Chase);
       /* if (GameManager.instance != null)
        {
            if (GameManager.instance.players != null)
            {
                AITarget = GameManager.instance.players[0].pawn.gameObject;
            }
        }*/
    }

    // Update is called once per frame
    public override void Update()
    {
        MakeDecisions();
    }
    public override void MakeDecisions()
    {
        switch (currentState)
        {
            case AIStates.Idle:
                IdleState();
                if (IsTimePassed(3))
                {
                    ChangeState(AIStates.Patrol);
                }
                break;
            case AIStates.Patrol:
                PatrolState();
                if (IsTimePassed(4))
                {
                    ChangeState(AIStates.Chase);
                }
                break;
            case AIStates.Chase:
                ChaseState();
                /*if (IsTimePassed(1))
                {
                    ChangeState(AIStates.Attack);
                }*/
                break;
            case AIStates.Attack:
                AttackState();
               /* if (IsTimePassed(1))
                {
                    ChangeState(AIStates.Patrol);
                }*/
                break;
            case AIStates.ChooseTarget:
                ChangeTargetState();
                ChangeState(AIStates.Chase);
                break;
        }
    }
}
