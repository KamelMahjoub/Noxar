using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageable
{


    //Rigidbody2d reference
    private Rigidbody2D _rigid;

    //Variable for jumpforce
    [SerializeField]
    private float _jumpForce = 8.0f;

    public int Health { get; set; }

    public int Coins;


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
        Health = 6;
        
    } 

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (CrossPlatformInputManager.GetButtonDown("Attack_Button") && IsGrounded() == true)
        {
            _playerAnim.Attack();
        }
        UIManager.Instance.UpdateCoinCount(Coins);

    }

    void Movement()
    {

        if (Health < 1)
        {
            return;
        }
        //check for horizental input (left/right) 
        float move = CrossPlatformInputManager.GetAxis("Horizontal");

        _grounded = IsGrounded();

        Flip(move);



        //Jumping
        //if space key is pressed && grounded = true 
        if ((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("Jump_Button")) && IsGrounded() == true)
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
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, 1 << 6);

        Debug.DrawRay(transform.position, Vector2.down * 1.5f, Color.green);

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
           // _playerSprite.flipX = false;
            transform.eulerAngles = new Vector3(0, 0, 0);


        }
        else if (move < 0)
        {      
            transform.eulerAngles = new Vector3(0, 180, 0);
           
        }
    }


    public void Damage()
    {
        if (Health < 1)
        {
            return;
        }

        Debug.Log("Player damaged");
        //remove 1 health
        Health--;
        //update ui display
        UIManager.Instance.UpdateLives(Health);
        //check for dead

        if (Health < 1)
        {
            _playerAnim.Death();
        }
        //play death animation

    }

    public void AddCoins(int amount)
    {
        Coins += amount;
       UIManager.Instance.UpdateCoinCount(Coins);
    }

    public void SubstractCoins(int amount)
    {
        Coins -= amount;
        UIManager.Instance.UpdateCoinCount(Coins);
    }
}

