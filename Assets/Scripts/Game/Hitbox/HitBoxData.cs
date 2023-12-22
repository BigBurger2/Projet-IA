using UnityEngine;

[CreateAssetMenu(fileName = "HitboxData", menuName = "HitBoxData/new Data")]
public class HitBoxData : ScriptableObject
{
    public AgentAttack attack;
    public TeamTag sourceTeam;
    public bool isMelee;
    public float damage;

    public float delay;
    public float ttl;
    public float range;
    
    public GameObject prefab;
}