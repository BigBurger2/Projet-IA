using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Hitbox : MonoBehaviour
{
    [SerializeField]
    private HitBoxData datas;

    [SerializeField]
    private Collider2D collider;

    private bool isActive = false;
    
    private float timepassed;
    
    private GameObject context;

    private float speed;
    public void Bind(GameObject context)
    {
        this.context = context;
    }
    
    private void OnEnable()
    {
        timepassed = 0;
        speed = datas.range / (datas.ttl - datas.delay);
    }

    private void Update()
    {
        timepassed += Time.deltaTime;

        if (!isActive  && timepassed >= datas.delay)
        {
            collider.enabled = true;
            isActive = true;
        }

        if (isActive)
        {
            ICanSelectTarget e = context.GetComponent<Entity>() as ICanSelectTarget;
            if (!datas.isMelee)
            {
                var targetPos = e.GetTarget().transform.position;
                var currentpos = context.transform.position;
                var diff = targetPos - currentpos;
                gameObject.transform.position += diff.normalized *speed;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
            }
            
            if (timepassed >= datas.ttl)
            {
                if (datas.isMelee)
                {
                    var targetPos = e.GetTarget().transform.position;
                    var currentpos = context.transform.position;
                    var diff = targetPos - currentpos;
                    context.transform.position += diff.normalized * (datas.range * 1.5f);
                }

                collider.enabled = false;
                gameObject.SetActive(false);
            }
        }
        

        
    }
}
