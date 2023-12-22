using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V12;
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
    private HitBoxBank hbBank;
    
    [SerializeField] private float chaseSpeed = 10;
    [SerializeField] private List<HitBoxData> hitboxesDatas;

    private void Start()
    {
        hpComponent = GetComponent<HpComponent>();
        navagent= GetComponent<NavMeshAgent>();

        navagent.updateRotation = false;
        navagent.updateUpAxis = false;

        GameObject hitboxBank = new GameObject("BossHitboxBank");
        hbBank = hitboxBank.AddComponent<HitBoxBank>();
        
        hbBank.Bind(gameObject);
        foreach (var hitBoxData in hitboxesDatas)
        {
            hbBank.AddHitbox(hitBoxData);
        }
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
        hbBank.EnableHitbox(AgentAttack.BossDash, player.transform.position);
    }

    public void DoTriBoomAtk()
    {
        Debug.Log("DoTriBoomAtk");
        navagent.isStopped = true;
        hbBank.EnableHitbox(AgentAttack.TriBoom, player.transform.position);
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
        if (player != null) {
            // verifier c cool
        }
    }

    public GameObject GetTarget()
    {
        return player;
    }
}
