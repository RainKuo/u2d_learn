using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float move_speed = 3;
    public SpriteRenderer sr;
    public Sprite[] tankSprites;
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public GameObject defendPrefeb;
    public Vector3 bulletEulerAngles;
    public bool isDefended;
    private float defendTimeVal = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        isDefended = true;
        defendTimeVal = 3.0f;
        defendPrefeb.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDefended)
        {
            defendTimeVal -= Time.deltaTime;
            if (defendTimeVal < 0) { 
                defendTimeVal = 0; 
                isDefended=false;
                defendPrefeb.SetActive(false);
            }
        }
        Attack();
    }

    public void FixedUpdate()
    {
        
        Move();        
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 生成一个实例
            GameObject obj = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEulerAngles));
            var bullet = obj.GetComponent<Bullet>();
            bullet.srcTag = gameObject.tag;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            default: break;
        }
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * h * move_speed * Time.deltaTime, Space.World);
        if (h > 0)
        {
            sr.sprite = tankSprites[1];
            bulletEulerAngles = new Vector3(0, 0, -90);
        }
        else if (h < 0)
        {
            sr.sprite = tankSprites[3];
            bulletEulerAngles = new Vector3(0, 0, 90);
        }
        if (h != 0)
        {
            return;
        }
        float v = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * v * move_speed * Time.deltaTime, Space.World);
        if (v > 0)
        {
            sr.sprite = tankSprites[0];
            bulletEulerAngles = new Vector3(0, 0, 0);
        }
        else if (v < 0)
        {
            sr.sprite = tankSprites[2];
            bulletEulerAngles = new Vector3(0, 0, -180);
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
        Instantiate(explosionPrefab, transform.position, transform.rotation);
    }
}
