using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parchePlataforma : MonoBehaviour
{
    private bool colisionConParche;
    private bool plataformaActivada;
    public Transform parche;
    private Collider2D colliderPlataforma;
    public GameObject desactivado;
    public GameObject activado;

    void Start()
    {
        colisionConParche = false;
        plataformaActivada = false;
        colliderPlataforma = GetComponent<Collider2D>();
        colliderPlataforma.enabled = false;
        desactivado.SetActive(true);
        activado.SetActive(false);


    }

    void Update()
    {
        if (Vector2.Distance(transform.position, parche.position) <= 1)
        {
            colisionConParche = true;
            Debug.Log("colision con parche");

            if (!plataformaActivada && colisionConParche && Input.GetKeyDown(KeyCode.C))
            {
                FindObjectOfType<AudioManager>().Play("magic1");

                plataformaActivada = true;
                colliderPlataforma.enabled = true;

                Debug.Log("plataforma activada");
                desactivado.SetActive(false);
                activado.SetActive(true);

            }

            if (plataformaActivada && Input.GetKeyUp(KeyCode.C))
            {
                FindObjectOfType<AudioManager>().Play("magic2");

                plataformaActivada = false;
                colliderPlataforma.enabled = false;

                Debug.Log("plataforma desactivada");
                desactivado.SetActive(true);
                activado.SetActive(false);

            }            
        }

        else if (Vector2.Distance(transform.position, parche.position) > 1.5)
        {
            colliderPlataforma.enabled = false;
            colisionConParche = false;
            plataformaActivada = false;
            desactivado.SetActive(true);
            activado.SetActive(false);
        }
        
    }
    

}
