using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetetectCaida : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Vector3 vector = new Vector3(transform.root.localScale.x * -1, transform.root.localScale.y, transform.root.localScale.z);
        transform.root.localScale = vector;
    }
}
