using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Door : MonoBehaviour
{

    [SerializeField] GameObject doors;
    [SerializeField] Enemy enemy;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            doors.SetActive(true);
            if (enemy != null) enemy.Agressive = true;
        }
        
    }

    public void OppenTheDoor()
    {
        doors.SetActive(false);
    }

}
