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
   
  
    void Update()
    {
        Movement();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground" )
        {
            canjump = true;
        }
        else if (collision.transform.tag == "cubo")
        {
            canjump = true;
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
