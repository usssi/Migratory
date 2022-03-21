using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parcheControler : MonoBehaviour
{

    public float followSpeed = 7.5f;
    public Transform targetBicho;
    public bool follow = true;
    public float vel;
    private Collider2D miCollider;
    [SerializeField] GameObject explosion;
    [SerializeField] private float delayExplosion = .5f;
    [SerializeField] bool canExplode = true;
    bool canMove = true;
    public gameController gC;



    void OnEnable()
    {
        //crea un array donde pone todos los objetos con el tag "Player"
        //loop foreach object en ese array llamado otherObjects
            //ignorar collision2D
        GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("Player");
                
        foreach (GameObject obj in otherObjects)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            
        }

    }

    void Start()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetBicho.position, followSpeed*5);

        follow = true;

        miCollider = GetComponent<Collider2D>();

        if (miCollider.enabled)
        {
            miCollider.enabled = false;
        }

    }


    void Update()
    {       
        Follow();
        Movement();
    }

    private void Follow()
    {
        if (canMove && follow && Vector2.Distance(transform.position, targetBicho.position) > 1.5)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetBicho.position, followSpeed * Time.deltaTime);            
        }
        if (canMove && Vector2.Distance(transform.position, targetBicho.position) > 8)
        {
            follow = true;
            miCollider.enabled = false;
        }
    }

    private void Movement()
        //movimiento de parche
    {
        
        if (canMove && Input.GetKey(KeyCode.D))
        {
            transform.Translate(0, vel * Time.deltaTime, 0);
            follow = false;
            miCollider.enabled = true;
        }

        if (canMove && Input.GetKey(KeyCode.W))
        {
            transform.Translate(-vel * Time.deltaTime, 0, 0);
            follow = false;
            miCollider.enabled = true;
        }

        if (canMove && Input.GetKey(KeyCode.S))
        {
            transform.Translate(vel * Time.deltaTime, 0, 0);
            follow = false;
            miCollider.enabled = true;

        }

        if (canMove && Input.GetKey(KeyCode.A))
        {
            transform.Translate(0, -vel * Time.deltaTime, 0);
            follow = false;
            miCollider.enabled = true;
        }

        // E para activar follow

        if (canMove && Input.GetKey(KeyCode.E))
        {
            follow = true;
            miCollider.enabled = false;
        }

        //controlador de explosion

        if (gC.jugando && !follow && canExplode && Input.GetKeyDown("space"))
        {
            canMove = false;
            explosion.SetActive(true);
            Debug.Log("PUUUUM libre");
            Invoke("ExplosionOff", delayExplosion * 1.5f);
            canExplode = false;
        }
        else if (gC.jugando && follow && canExplode && Input.GetKeyDown("space") && Vector2.Distance(transform.position, targetBicho.position) <= 2.5)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetBicho.position, 500);
            canMove = false;
            explosion.SetActive(true);
            Debug.Log("PUUUUM follow tp");
            Invoke("ExplosionOff", delayExplosion * 1.5f);
            canExplode = false;
        }
        else if (gC.jugando && follow && canExplode && Input.GetKeyDown("space") && Vector2.Distance(transform.position, targetBicho.position) >= 2.5)
        {
            canMove = false;
            explosion.SetActive(true);
            Debug.Log("PUUUUM follow lejos");
            Invoke("ExplosionOff", delayExplosion * 1.5f);
            canExplode = false;
        }
    }
     
    void ExplosionOff()
    {
        canMove = true;
        explosion.SetActive(false);
        Debug.Log("explosion off");
        Invoke("ExplosionWait", delayExplosion*2f);
    }

    void ExplosionWait()
    {
        canExplode = true;
        Debug.Log("can explode");
    }
    
}
