using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Debug.Log("sr order " + sr.sortingOrder);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dead()
    {
        sr.sprite = sprite;
    }
}
