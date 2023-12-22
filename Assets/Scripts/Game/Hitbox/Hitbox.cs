using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V20;
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
            if (datas.isMelee)
            {
                var targetPos = new Vector2(Mathf.Sin((gameObject.transform.rotation.z) * Mathf.Deg2Rad), Mathf.Cos((gameObject.transform.rotation.z) * Mathf.Deg2Rad)) * -speed;
                var currentpos= context.transform.position ;
                context.transform.position = new Vector3(currentpos.x + targetPos.x,currentpos.y - targetPos.y,0);
            }
            else
            {
                gameObject.transform.position = gameObject.transform.forward * speed;
            }
            
            if (timepassed >= datas.ttl)
            {
                collider.enabled = false;
                gameObject.SetActive(false);
            }
        }
        

        
    }
}
