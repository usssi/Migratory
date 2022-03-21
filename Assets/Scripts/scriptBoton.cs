using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptBoton : MonoBehaviour
{
    [SerializeField] GameObject plataforma;
    [SerializeField] Transform parche;
    public GameObject celeste;
    public GameObject blanco;


    bool canBePressed;
    bool levantar;
    bool bajar;

    public float alturaMaxima;
    public float alturaMinima;

    private void Start()
    {
        canBePressed = true;
        levantar = false;
        bajar = true;
        celeste.SetActive(false);
        blanco.SetActive(true);
    }

    private void Update()
    {
        if (canBePressed && Vector2.Distance(transform.position, parche.position)< 1)
        {
            Debug.Log("bicho apreta boton");
            FindObjectOfType<AudioManager>().Play("botonUp");
            FindObjectOfType<AudioManager>().Play("magic1");

            transform.position = new Vector2(transform.position.x, transform.position.y - .1f);
            canBePressed = false;
            bajar = false;
            levantar = true;
            celeste.SetActive(true);
            blanco.SetActive(false);

        }
        else if (!canBePressed && Vector2.Distance(transform.position, parche.position) > 1)
        {
            Debug.Log("bicho NO apreta boton");
            FindObjectOfType<AudioManager>().Play("botonDown");
            FindObjectOfType<AudioManager>().Play("magic2");

            transform.position = new Vector2(transform.position.x, transform.position.y + .1f);
            canBePressed = true;
            bajar = true;
            levantar = false;
            celeste.SetActive(false);
            blanco.SetActive(true);
        }
        
    }

    private void FixedUpdate()
    {
        if (bajar)
        {
            if (plataforma.transform.position.y > alturaMinima)
            {
                plataforma.transform.position -= new Vector3(0, .05f, 0);

            }
        }

        if (levantar)
        {
            if (plataforma.transform.position.y <= alturaMaxima)
            {
                plataforma.transform.position += new Vector3(0, .1f, 0);

            }
        }

    }

}
