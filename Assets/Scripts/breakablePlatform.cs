using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakablePlatform : MonoBehaviour
{
    private Collider2D colliderPlataforma;
   
    public float tiempoDeDespawn;
    public float tiempoDeRespawn;
    public bool respawn;

    void Start()
    {
        colliderPlataforma = GetComponent<Collider2D>();
    }

    void Update()
    {
        //if (colisionando)
        //{
        //    Invoke("SonidoDeCrackeo", tiempoDeCrackeo);
        //    Invoke("DesactivarPlataforma", tiempoDeDespawn);
        //    Invoke("ActivarPlataforma", tiempoDeDespawn*2*Time.deltaTime);
        //}

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("plataformaBreak");
            Invoke("DesactivarPlataforma", tiempoDeDespawn);

            if (respawn)
            {
                Invoke("ActivarPlataforma", tiempoDeRespawn);

            }

        }
    }
    
    private void DesactivarPlataforma()
    {
        FindObjectOfType<AudioManager>().Play("cuboBreak");

        gameObject.SetActive(false);

    }

    private void ActivarPlataforma()
    {
        gameObject.SetActive(true);

    }
}
