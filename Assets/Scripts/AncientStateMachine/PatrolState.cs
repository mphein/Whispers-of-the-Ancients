using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int waypointIndex;
    public float waitTimer;
    public override void Enter()
    {
    }

    public override void Perform()
    {
        PatrolCycle();
        if (ancient.CanSeePlayer())
        {
            stateMachine.changeState(new FollowState());
        }
    }

    public override void Exit()
    {
    }

    public void PatrolCycle()
    {
        if (ancient.Agent.remainingDistance < .2f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer > .5)
            {
                if (waypointIndex < ancient.path.waypoints.Count - 1)
                    waypointIndex++;
                else
                    waypointIndex = 0;
                ancient.Agent.SetDestination(ancient.path.waypoints[waypointIndex].position);
                waitTimer = 0;
            }
        }
    }
}
