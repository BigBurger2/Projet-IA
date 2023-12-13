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
    [HideInInspector]
    public bool fired;
    [HideInInspector]
    public Vector2 Dir;

    public Rigidbody2D rb;

    public WeaponData weaponData;

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
            if ((startPos - new Vector2(transform.position.x, transform.position.y)).magnitude < weaponData.range)
            {
                rb.velocity = Dir * weaponData.weaponSpeed;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    public IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(1/weaponData.fireRate);
        }
    }
}
