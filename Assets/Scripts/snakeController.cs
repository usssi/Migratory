using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class snakeController : MonoBehaviour
{
    public Transform player;
    public Transform parche;
    public float agroRange;    
    public float moveSpeed;
    Rigidbody2D rb2d;
    [SerializeField] bool canKill = true;
    [SerializeField] bool canDie = true;
    public float velCaida = -2f;
    public bool hasHat = false;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float disToPlayer = Vector2.Distance(transform.position, player.position);
       

        //Debug.Log(disToPlayer);
        if (disToPlayer < agroRange)
        {
            ChasePlayer();
            Debug.Log("te veo player");            
        }
        else if (disToPlayer > agroRange)
        {
            StopChasingPlayer();
            rb2d.velocity = new Vector2(0, velCaida);
        }       

    }

    private void ChasePlayer()
    {
        if (transform.position.x <= player.position.x -.5f)
        {
            rb2d.velocity = new Vector2(moveSpeed*1.5f, velCaida);
            transform.localScale = new Vector3(-8f, 8f, 0f);

        }
        else if (transform.position.x >= player.position.x +.5f)
        {
            rb2d.velocity = new Vector2(-moveSpeed*1.5f, velCaida);
            transform.localScale = new Vector3(8f, 8f, 0f);

        }
    }

    private void StopChasingPlayer()
    {
        rb2d.velocity = Vector2.zero;
    }
    

    //cuando el cubo colisiona con el trigger de arriba la serpiente se destrute
    private void OnTriggerEnter2D(Collider2D collision)
    {        

        if (!hasHat && canDie && collision.gameObject.tag == "cubo")
        {
            Debug.Log("la serpiente fue apalstada");
            Die();

        }
        else if (hasHat && canDie && collision.gameObject.tag == "cubo")
        {
            Debug.Log("has hat brake cube");
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("cuboBreak");

        }

        if (canDie && collision.gameObject.tag == "explosion")
        {
            Debug.Log("la serpiente exploto");
            Die();

        }

    }


  
    //cuando colisiona el player o parche mueres o sea se reinicia la escena
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canKill && collision.gameObject.tag == "Player")
        {
            Debug.Log("la serpiente mató player");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (canKill && collision.gameObject.tag == "parche")
        {
            Debug.Log("la serpiente mató parche");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
        FindObjectOfType<AudioManager>().Play("snakeDead");
    }
   
}
