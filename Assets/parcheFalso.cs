using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parcheFalso : MonoBehaviour
{
    public Transform bicho;
    public int velocidad;
    private bool alejarse;
    public bool falso2;
    public Transform posicionParche;
    public GameObject parcheReal;
    private bool canDespawn;
    // Start is called before the first frame update
    void Start()
    {
        canDespawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!falso2 && Vector2.Distance(transform.position, bicho.position) < 5)
        {
            alejarse = true;
        }
        else if (!falso2 && Vector2.Distance(transform.position, bicho.position) > 14)
        {
            alejarse = false;
        }

        if (!falso2 && alejarse)
        {
            transform.Translate(0, -velocidad * Time.deltaTime, 0);
        }

        if (falso2 && Vector2.Distance(transform.position, bicho.position) < 4)
        {
            alejarse = true;

        }
        else if (falso2 && Vector2.Distance(transform.position, bicho.position) > 14)
        {
            alejarse = false;
        }

        if (falso2 && alejarse)
        {
            transform.position = Vector2.MoveTowards(transform.position, posicionParche.position, velocidad*1.5f * Time.deltaTime);
            canDespawn = true;

        }

        if (falso2 && canDespawn)
        {
            if (Vector2.Distance(transform.position, bicho.position) < 2)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    parcheReal.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
            
        }

    }

}
