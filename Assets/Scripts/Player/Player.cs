using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    //Rigidbody2d reference
    private Rigidbody2D _rigid;

    //Variable for jumpforce
    [SerializeField]
    private float _jumpForce = 8.0f;

    private bool _resetJump = false;

   
    [SerializeField]
    private float _speed = 3f;

    //variable for grounded : if the char is on the ground or no
    private bool _grounded = false;

    
    private PlayerAnimation _playerAnim;

    private SpriteRenderer _playerSprite;


    


    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        
    } 

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    
    void Movement()
    {
        //check for horizental input (left/right) 
        float move = Input.GetAxisRaw("Horizontal");

       _grounded = IsGrounded();

        Flip(move);
       

     
        //Jumping
        //if space key is pressed && grounded = true 
       if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            //jump!
            //current velocity = new velocity(Current x , Jumpforce) 
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
            _playerAnim.Jump(true);
        }

        //Current velocity = new velocity(HorizontalInput,Current velocity-y);
        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);

        this._playerAnim.Move(move);

    }
   
   bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 6);

        Debug.DrawRay(transform.position, Vector2.down * 1f, Color.green);

        if (hitInfo.collider != null)
        {
            if (_resetJump == false)
            {
                _playerAnim.Jump(false);
                return true;
            }

        }
        return false;
    }


    //change the variable value after 0.1 seconds
    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }


    void Flip(float move)
    {
        if (move > 0)
        {
            _playerSprite.flipX = false;
            

        }
        else if (move < 0)
        {
            _playerSprite.flipX = true;

        }
    }
}

