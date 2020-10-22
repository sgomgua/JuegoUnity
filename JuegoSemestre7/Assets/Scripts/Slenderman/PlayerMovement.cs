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


    //jump
    private bool enSuelo = true;
    public Transform comrobarSuelo;
    float comprobarRadio = 0.07f;
    public LayerMask mascaraSuelo;

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
        
        enSuelo = Physics2D.OverlapCircle(comrobarSuelo.position, comprobarRadio, mascaraSuelo);
        forceVector = new Vector2(movX, 0f) * forceMultiplier;

        rb.AddForce(forceVector, ForceMode2D.Force);
        //if (enSuelo)
        //{
        //    salto2 = false;
        //}
        if ((enSuelo) && jump > 0)
        {
            rb.AddForce(Vector2.up * jumpMultiplier, ForceMode2D.Impulse);
            //if (!salto2 && !enSuelo)
            //{
            //    salto2 = true;
            //}
        }

    }
}