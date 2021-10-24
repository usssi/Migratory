using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parcheControllerConFisicas : MonoBehaviour
{
    public float followSpeed = 7.5f;
    public Transform target;
    public bool follow = true;
    public float vel;
    private Collider2D miCollider;

    void OnEnable()
    {
        //crea un array donde pone todos los objetos con el tag "Player"
        //loop foreach object en ese array llamado otherObjects
        //ignorar collision2D
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject obj in playerObjects)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("ground");

        foreach (GameObject obj in otherObjects)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

    }

    void Start()
    {
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
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Follow()
    {
        if (follow && Vector2.Distance(transform.position, target.position) > 1.5)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
        }
    }

    private void Movement()
    //movimiento de parche
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(vel * Time.deltaTime, 0));

            follow = false;
            miCollider.enabled = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, vel * Time.deltaTime));

            follow = false;
            miCollider.enabled = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -vel * Time.deltaTime));
            follow = false;
            miCollider.enabled = true;

        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-vel * Time.deltaTime, 0));
            follow = false;
            miCollider.enabled = true;
        }

        // E para activar follow
        if (Input.GetKey(KeyCode.E))
        {
            follow = true;
            miCollider.enabled = false;
        }

        //codigo espagetti de prueba
        //cuando apreto las flechas se activa el follow

        if (Input.GetKey("left"))
        {
            follow = true;
            miCollider.enabled = false;
        }

        if (Input.GetKey("right"))
        {
            follow = true;
            miCollider.enabled = false;
        }

        if (Input.GetKeyDown("up"))
        {
            follow = true;
            miCollider.enabled = false;
        }

    }

}
