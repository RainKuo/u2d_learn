using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int bulletSpeed = 10;
    public string srcTag = "";
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log("layout: " + spriteRenderer.sortingOrder);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * bulletSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {               
        bool attactedAnything = true;
        Debug.Log("OnTriggerEnter2D" + collision.tag);
        Debug.Log("SrcTag:" + srcTag);
        if (collision.tag == srcTag)
        {
            return;
        }
        switch (collision.tag)
        {
            case "Wall":
                {
                    Destroy(collision.gameObject);
                }
                break;
            case "Tank":
                {
                    Player player = collision.gameObject.GetComponent<Player>();
                    if (player != null)
                    {
                        if (!player.isDefended)
                        {
                            player.Dead();
                        }                        
                    }                    
                }
                break;
            case "Heart":
                {
                    Heart heart = collision.gameObject.GetComponent<Heart>();
                    if (heart != null)
                    {
                        heart.Dead();
                    }
                }
                break;

            default:
                attactedAnything = false;
                break;
        }
        if (attactedAnything)
        {
            Destroy(gameObject);       
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
