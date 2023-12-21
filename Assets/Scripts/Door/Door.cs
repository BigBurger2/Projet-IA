using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Door : MonoBehaviour
{

    [SerializeField] GameObject doors;
    [SerializeField] List<Enemy> enemy;
    private bool active = false;

    public bool Active { get => active; }


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
            if (enemy != null)
            {
                foreach (var ennemie in enemy)
                {
                    ennemie.Agressive = true;
                    
                }
            }

            active = true;
        }
        
    }

    public void OppenTheDoor()
    {
        doors.SetActive(false);
        active = false;
    }

   

}
