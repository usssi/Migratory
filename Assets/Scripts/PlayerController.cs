using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float run = 1f;
    float jumpRun = 1f;
    bool canjump;
    public float vel = 500f;
    public float jump = 500f;
    bool canMove = true;
    bool canExplode = true;
    public gameController gcPlayer;

    private int der = 1;
    private int izq = 2;
    [SerializeField] float tpXder;
    [SerializeField] float tpYder;
    [SerializeField] float tpXizq;
    [SerializeField] float tpYizq;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("origen") == der)
        {
            Debug.Log("bicho viene de la izquierda");
            transform.position = new Vector2(tpXizq, tpYizq); 
            transform.localScale = new Vector3(-8, 8, 1);



        }
        else if (PlayerPrefs.GetInt("origen") == izq)
        {
            Debug.Log("bicho viene de la derecha");
            transform.position = new Vector2(tpXder, tpYder);
            transform.localScale = new Vector3(8, 8, 1);
        }
        else if (PlayerPrefs.GetInt("origen") == 0)
        {
            Debug.Log("bicho sale de la casa");
            //transform.position = new Vector2(tpXder, tpYder);
            //transform.localScale = new Vector3(8, 8, 1);
        }
    }

    private void Start()
    {
        canMove = true;

    }
    void Update()
    {
        Movement();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground" )
        {
            canjump = true;
            Debug.Log("bicho colisiona con ground");
        }
        else if (collision.transform.tag == "cubo")
        {
            canjump = true;
            Debug.Log("bicho colisiona con cubo");
        }
        /*
        else
        {
            canjump = false;
        } */
        
    }



   
    void Movement() 
    { 
        if (gcPlayer.jugando && canMove && Input.GetKey("left"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-vel * run * Time.deltaTime, 0));
            transform.localScale = new Vector3(-8f, 8f, 0f);
        }                

        if (gcPlayer.jugando && canMove && Input.GetKey("right"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(vel * run * Time.deltaTime, 0));    
            transform.localScale = new Vector3(8f, 8f, 0f);
        }       

        if (gcPlayer.jugando && canMove && Input.GetKeyDown("up") && canjump)
        {
            canjump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump * jumpRun));
            
        }
        

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {           
            run = 1.5f;
            jumpRun = 1.2f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {           
            run = 1f;
            jumpRun = 1f;
        }

        if (canExplode && Input.GetKeyDown("space"))
        {
            canMove = false;
            canExplode = false;
            Invoke("Move", .5f);
        }
    }
    
    void Move()
    {
        canMove = true;
        Invoke("Explode", .75f);

    }
    void Explode()
    {
        canExplode = true;
    }
}
