using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    #region Events
    public event System.Action<Entity> OnDeathEvent;
    #endregion

    public abstract void OnDeath();

    protected void CallEvent()
    {
        OnDeathEvent?.Invoke(gameObject.GetComponent<Entity>());
    }
}
