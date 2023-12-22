using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V20;
using UnityEngine;


public enum AgentAttack
{
    TriBoom,
    BigBoom, 
    BossDash
}

public class HitBoxBank : MonoBehaviour
{
    private GameObject context;

    private Dictionary<AgentAttack, GameObject> hitboxes = new ();
    
    public void Bind(GameObject context)
    {
        this.context = context;
    }
    
    public void AddHitbox(HitBoxData hbdata)
    {
        GameObject hitbox = Instantiate(hbdata.prefab, gameObject.transform);
        hitbox.SetActive(false);
        hitbox.GetComponent<Hitbox>().Bind(context);
        hitboxes.Add(hbdata.attack, hitbox);
    }

    public void EnableHitbox(AgentAttack key, Vector2 targetPosition)
    {
        var hitbox = hitboxes[key];
        Vector2 hitboxPosition = context.transform.position;
        hitbox.transform.position = hitboxPosition;
        //rotate to face target 
        {
            Vector3 targ = targetPosition;
            targ.z = 0f;

            Vector3 objectPos = hitbox.transform.position;
            targ.x = targ.x - objectPos.x;
            targ.y = targ.y - objectPos.y;

            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg - 90;
            hitbox.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        
        // Enable
        {
            hitbox.SetActive(true);
        }
    }
}
