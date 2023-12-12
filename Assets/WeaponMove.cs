using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMove : MonoBehaviour
{
    [Range(1f, 50f)]
    public float weaponSpeed;
    [HideInInspector]
    public Vector2 targetPos;
    public bool fired;
    public Rigidbody2D rb;
    public Vector2 Dir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (fired)
        {
            rb.velocity = Dir * weaponSpeed;
        }
    }
}
