using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HpComponent))]
public class EnnemyCollision : MonoBehaviour
{
    private HpComponent hpComponent;

    [SerializeField]
    private float timeInvicibility;

    private bool isInvincible;

    Coroutine coroutine;

    private float timeLastHit = 0;
    private bool hit = false;

    [SerializeField] private TeamTag team;

    private void Start()
    {
        hpComponent = GetComponent<HpComponent>();
        isInvincible = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ennemy" && !isInvincible) // TODO revoir la condition
        {
            coroutine = StartCoroutine(Invicibility(collision.gameObject.GetComponent<CollisionDammage>().GetDammage()));
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ennemy" && !isInvincible) // TODO revoir la condition
        {
            if (hit)
                timeLastHit = Time.time;
            StopCoroutine(coroutine);
            hit = false;
        }
    }

    private IEnumerator Invicibility(float dammage)
    {
        yield return new WaitForSeconds(timeInvicibility - (Time.time - timeLastHit));
        while (true)
        {
            hpComponent.ChangeValue(-dammage);
            hit = true;
            Debug.Log("Hit");
            yield return new WaitForSeconds(timeInvicibility);
        }
    }
}
