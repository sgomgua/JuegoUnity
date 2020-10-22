using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovementGolem : MonoBehaviour
{
    private float movX, movY, jump;
    public float maxSpeed = 1f;
    public float speed = 1f;
    public Animator anim;

    public float forceMultiplier, jumpMultiplier;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector2.right * speed);
        float limitedSpeed = Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed);
        rb.velocity = new Vector2(limitedSpeed, rb.velocity.y);
        if (rb.velocity.x > -0.01f && rb.velocity.x < 0.01f)
        {
            speed = -speed;
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        if (speed > 0 )
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (speed < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
