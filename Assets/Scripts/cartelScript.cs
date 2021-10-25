using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartelScript : MonoBehaviour
{
    private bool bichoColisionaCartel = false;
    [SerializeField] string textoCartel;

    private void Start()
    {
        bichoColisionaCartel = false;
    }
    private void Update()
    {
        if (bichoColisionaCartel && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log(textoCartel);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bichoColisionaCartel = true;
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bichoColisionaCartel = false;
        }
    }


}
