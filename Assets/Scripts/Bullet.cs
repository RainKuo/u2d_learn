using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int bulletSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * bulletSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {               
        if (collision.tag == "Wall")
        {
            Debug.Log("OnTriggerEnter2D" + collision.tag);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Wall")        
        {
            Debug.Log("OnTriggerExit2D" + collision.tag);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Debug.Log("OntriggerStay2D");
        }
    }
}
