using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Weapon : MonoBehaviour
{
    [HideInInspector]
    public Vector2 targetPos;
    [HideInInspector]
    public Vector2 startPos;

    private bool fired;
    [HideInInspector]
    public Vector2 Dir;

    public Rigidbody2D rb;

    public WeaponData weaponData;

    [SerializeField]
    private SpriteRenderer spriteRenderer;


    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        spriteRenderer.sprite = weaponData.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (fired)
        {
            if ((startPos - new Vector2(transform.position.x, transform.position.y)).magnitude >= weaponData.range)
            {
                fired = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void Fire(Vector2 _Dir)
    {
        startPos = transform.position;
        Dir = _Dir.normalized;
        gameObject.SetActive(true);
        fired = true;
        rb.velocity = Dir * weaponData.weaponSpeed;
    }

    public TeamTag GetSource()
    {
        return weaponData.source;
    }
}
