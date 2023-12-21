using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Entity
{
    public override void OnDeath()
    {
        Debug.Log("You killed the boss it's time for feedbacks");
        Destroy(gameObject);
    }
}
