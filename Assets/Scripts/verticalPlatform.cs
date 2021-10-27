using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;
    private bool colisionando;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = .2f;
        }

        if (colisionando && Input.GetKey(KeyCode.DownArrow))
        {
            if (waitTime<=0)
            {
                effector.rotationalOffset = 180f;
                waitTime = .2f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            effector.rotationalOffset = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            colisionando = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            colisionando = false;
        }
    }
}
