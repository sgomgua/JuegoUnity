using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovementGhost : MonoBehaviour
{
    private float movX, movY, jump;
    public float maxSpeed = 1f;
    public float speed = 1f;
    public float forceMultiplier, jumpMultiplier;
    public Animator anim;
    private Transform ObjectToFollow = null;
    public Transform proximidad;
    private Rigidbody2D rb;
    public LayerMask layerPlayerMask;
    private float comprobadorProximidad = 4f;
    private bool inRango = false;
    // Start is called before the first frame update
    void Start()
    {
        ObjectToFollow = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjectToFollow == null)
            return;
        inRango = Physics2D.OverlapCircle(proximidad.position, comprobadorProximidad, layerPlayerMask);
        //double proximidad = ObjectToFollow.transform.position.x - transform.position.x;
        if (inRango)
        {
            transform.position = Vector2.MoveTowards(transform.position, ObjectToFollow.transform.position, speed * Time.deltaTime);
            Vector3 DirectionToFollow = ObjectToFollow.position - transform.position;
            if (ObjectToFollow.transform.position.x > transform.position.x )
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (ObjectToFollow.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
        else
        {
            rb.AddForce(Vector2.right * speed);
            float limitedSpeed = Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed);
            rb.velocity = new Vector2(limitedSpeed, rb.velocity.y);
            if (rb.velocity.x > -0.01f && rb.velocity.x < 0.01f)
            {
                speed = -speed;
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            if (speed > 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (speed < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
        
    }

    public void FixedUpdate() 
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Destroy(gameObject);
        }
    }

}
