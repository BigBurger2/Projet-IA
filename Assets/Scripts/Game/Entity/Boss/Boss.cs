using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(UpdateAnimatorAgent))]
[RequireComponent(typeof(HpComponent))]
public class Boss : Entity, ICanBigZoneAtk, iCanDashAtk, ICanTriBoomAtk, ICanWaitPlayer,ICanLowHp,ICanChasePlayer, ICanSelectTarget
{
    [SerializeField]
    private GameObject player;

    private HpComponent hpComponent;
    private NavMeshAgent navagent;
    
    [SerializeField] private float chaseSpeed = 10;
    
    private void Start()
    {
        hpComponent = GetComponent<HpComponent>();
        navagent= GetComponent<NavMeshAgent>();

        navagent.updateRotation = false;
        navagent.updateUpAxis = false;
    }

    
    public GameObject GetPlayer()
    {
        return player;
    }
    
    public override void OnDeath()
    {
        Debug.Log("You killed the boss it's time for feedbacks");
        Destroy(gameObject);
    }

    public void DoBigZoneAttack()
    {
        Debug.Log("DoBigZoneAttack");
        navagent.isStopped = true;
        
    }

    public void DoDashAtk()
    {
        Debug.Log("DoDashAtk");
        navagent.isStopped = true;
        
    }

    public void DoTriBoomAtk()
    {
        Debug.Log("DoTriBoomAtk");
        navagent.isStopped = true;
    }

    public bool DoWaitFoPlayer()
    {
        Debug.Log("DoWaitFoPlayer");
        return Vector2.Distance(player.transform.position, transform.position) < 6;
    }

    public bool IsLowHp()
    {
        Debug.Log("IsLowHp");
        return hpComponent.GetCurrentHp() <= 1500;
    }

    public bool DoChasePlayer(float distanceWanted)
    {
        Debug.Log("DoChasePlayer");
        if (Vector2.Distance(player.transform.position, transform.position) >= distanceWanted)
        {
            navagent.isStopped = false;
            navagent.speed = chaseSpeed;
            navagent.SetDestination(player.transform.position);
            return false;
        }
        navagent.isStopped = true;
        return true;
    }

    public void DoSelectTarget()
    {
        Debug.Log("DoSelectTarget");
        //wpManager.SetTarget(player);
    }
}
