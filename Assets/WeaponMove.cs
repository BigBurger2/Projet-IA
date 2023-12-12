using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WeaponMove : MonoBehaviour
{
    [Range(1f, 50f)]
    public float weaponSpeed;
    [HideInInspector]
    public Vector2 targetPos;
    [HideInInspector]
    public Vector2 startPos;

    [HideInInspector]
    public bool fired;
    public Rigidbody2D rb;
    [HideInInspector]
    public Vector2 Dir;

    [Range(1, 50)]
    public int range;

    public GameObject target;


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
            if ((startPos - new Vector2(transform.position.x, transform.position.y)).magnitude < range)
            {
                rb.velocity = Dir * weaponSpeed;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
