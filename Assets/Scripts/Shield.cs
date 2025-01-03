using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = new Vector3 (0, 0, -1);
    // Start is called before the first frame update
    void Start()
    {
        Renderer rd = GetComponent<Renderer>();
        rd.sortingOrder = player.GetComponent<Renderer>().sortingOrder - 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + player.position;
    }
}
