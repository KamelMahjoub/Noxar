using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    //Rigidbody2d reference
    private Rigidbody2D _rigid;
    //Variable for jumpforce
    [SerializeField]
    private float _jumpForce = 5.0f;
    //variable for grounded : if the char is on the ground or no
    [SerializeField]
    private bool _grounded = false;
    private bool resetJumpNeeded = false;


    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    } 

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_grounded);
        Movement();
        CheckGrounded();
    }
    
    void Movement()
    {
        //check for horizental input (left/right) 
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        //Current velocity = new velocity(HorizontalInput,Current velocity-y);
        _rigid.velocity = new Vector2(horizontalInput, _rigid.velocity.y);

        //Jumping
        //if space key is pressed && grounded = true 
        if (Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {
            //jump!
            //current velocity = new velicy(Current x , Jumpforce) 
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            _grounded = false;
            //jump cooldown 
            resetJumpNeeded = true;
            StartCoroutine(ResetJumpNeededRoutine());
        }

    }
    void CheckGrounded()
    {
        //Raycasting to check if the player is on the ground or not , also sets the value of grounded to true or false
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 6);
        //shows the ray/line to see if the ray is configured succesfully
        Debug.DrawRay(transform.position, Vector2.down * 1f, Color.green);
        //if there's a collision , ray hits the ground
        if (hitInfo.collider != null)
        {
            if (resetJumpNeeded == false)
                _grounded = true;
        }
    }


    //change the variable value after 0.1 seconds
    IEnumerator ResetJumpNeededRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        resetJumpNeeded = false;
    }



}

