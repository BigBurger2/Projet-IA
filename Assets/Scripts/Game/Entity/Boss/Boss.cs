using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Entity, ICanBigZoneAtk, iCanDashAtk, ICanTriBoomAtk, ICanWaitPlayer,ICanLowHp,ICanChasePlayer, ICanSelectTarget
{
    [SerializeField]
    private GameObject player;

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
        throw new System.NotImplementedException();
    }

    public void DoDashAtk()
    {
        throw new System.NotImplementedException();
    }

    public void DoTriBoomAtk()
    {
        throw new System.NotImplementedException();
    }

    public bool DoWaitFoPlayer()
    {
        throw new System.NotImplementedException();
    }

    public bool IsLowHp()
    {
        throw new System.NotImplementedException();
    }

    public float DoChasePlayer()
    {
        throw new System.NotImplementedException();
    }

    public void DoSelectTarget()
    {
        throw new System.NotImplementedException();
    }
}
