using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowState : BaseState
{

    private float moveTimer;
    private float losePlayerTimer;
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
       
    }

    public override void Perform()
    {
        if (ancient.CanSeePlayer())
        {
            losePlayerTimer = 0;
            ancient.transform.LookAt(ancient.Player.transform.position);
            ancient.Agent.SetDestination(ancient.Player.transform.position);
        }
        else
        {
            moveTimer += Time.deltaTime;
            if (moveTimer > Random.Range(1, 5))
            {
                ancient.Agent.SetDestination(ancient.transform.position + (Random.insideUnitSphere * 5));
            }
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 6)
            {
                Debug.Log(losePlayerTimer);
                stateMachine.changeState(new PatrolState());
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
