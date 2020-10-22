using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movX, movY, jump;
    private Vector2 forceVector;
    public Animator anim;

    public float forceMultiplier , jumpMultiplier;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");
        anim.SetFloat("Speed_X",Mathf.Abs(movX) );


        if (movX < 0f)
        {
            transform.localScale = new Vector3(-1.7f, 1.7f, 1f);
        }
        else{
            transform.localScale = new Vector3(1.7f, 1.7f, 1f);
        }
        
    }
    private void FixedUpdate()
    {
        forceVector = new Vector2(movX, 0f) * forceMultiplier;

        rb.AddForce(forceVector, ForceMode2D.Force);

        if (jump > 0)
        {
            rb.AddForce(Vector2.up * jumpMultiplier, ForceMode2D.Impulse);
        }
    }
}