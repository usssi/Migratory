using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptBotonMadera : MonoBehaviour
{
    [SerializeField] GameObject plataforma;


    bool canBePressed;
    bool levantar;
    bool bajar;
    public double alturaMaxima;
    public double alturaMinima;

    private void Start()
    {
        canBePressed = true;
        levantar = false;
        bajar = true;
    }

    private void FixedUpdate()
    {
        if (bajar && plataforma.transform.position.y <= alturaMaxima)
        {
            Debug.Log("se esta levantando");
            Levantar();

        }
        else if (levantar && plataforma.transform.position.y > alturaMinima)
        {
            Debug.Log("esta bajando");
            Bajar();

        }

    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canBePressed && collision.transform.tag == "cubo")
        {
            FindObjectOfType<AudioManager>().Play("botonUp");

            transform.position = new Vector2(transform.position.x ,transform.position.y-.1f );
            canBePressed = false;
            levantar = true;
            bajar = false;
        }
        else if (canBePressed && collision.transform.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("botonUp");

            transform.position = new Vector2(transform.position.x, transform.position.y - .1f);
            canBePressed = false;
            levantar = true;
            bajar = false;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "cubo")
        {
            FindObjectOfType<AudioManager>().Play("botonDown");

            transform.position = new Vector2(transform.position.x, transform.position.y + .1f);
            canBePressed = true;
            levantar = false;
            bajar = true;
        }

        if (collision.transform.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("botonDown");

            transform.position = new Vector2(transform.position.x, transform.position.y + .1f);
            canBePressed = true;
            levantar = false;
            bajar = true;
        }

    }

    void Levantar()
    {
        //velocidad de levantar
        plataforma.transform.position += new Vector3(0, .1f, 0);
    }

    void Bajar()
    {
        //velocidad de bajar
        plataforma.transform.position -= new Vector3(0, .05f, 0);
    }
}
