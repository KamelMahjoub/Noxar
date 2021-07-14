using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    //Rigidbody2d reference
    private Rigidbody2D _rigid;


    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    } 

    // Update is called once per frame
    void Update()
    {
        Movement();       
    }
    
    void Movement()
    {
        //check for horizental input (left/right) 
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        //Current velocity = new velocity(HorizontalInput,Current velocity-y);
        _rigid.velocity = new Vector2(horizontalInput, _rigid.velocity.y);     
    }

   
}

