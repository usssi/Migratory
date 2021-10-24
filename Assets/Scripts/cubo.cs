using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cubo : MonoBehaviour
{
    public bool respawn = true;

    void Update()
    {
        if (respawn == true && transform.position.x < 0 && transform.position.y <= -7)
        {
            Instantiate(this.gameObject, new Vector3(transform.position.x + -0.5f , 6.5f), Quaternion.identity);
            Destroy(this.gameObject);
            //transform.Translate ( new Vector3 (transform.position.x * -1.5f , 13 , transform.position.z) );
        }
        else if (respawn == true &&  transform.position.x > 0 && transform.position.y <= -7)
        {
            Instantiate(this.gameObject, new Vector3(transform.position.x + 0.5f, 6.5f), Quaternion.identity);
            Destroy(this.gameObject);
            //transform.Translate ( new Vector3 (transform.position.x * -1.5f , 13 , transform.position.z) );
        }
        else if (respawn == true &&  transform.position.x == 0 && transform.position.y <= -7)
        {
            Instantiate(this.gameObject, new Vector3(transform.position.x, 6.5f), Quaternion.identity);
            Destroy(this.gameObject);
            //transform.Translate ( new Vector3 (transform.position.x * -1.5f , 13 , transform.position.z) );
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            FindObjectOfType<AudioManager>().Play("cuboFloor");
            Debug.Log("cubo toca el piso");
        }
    }
}
