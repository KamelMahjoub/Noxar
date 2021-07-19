using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int coins;
    [SerializeField]
    protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;

    protected Player player;

    protected bool isHit = false;

    protected bool isDead = false;

    //public GameObject diamondPrefab;


    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Start()
    {
        Init();
    }

    public virtual void Update()
    {
       if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false)
        {
            return;
        }
        if (isDead == false)
            Movement();
    }


    public virtual void Movement()
    {
        if (currentTarget == pointA.position)
        {
            
          //  sprite.flipX = true;
            transform.eulerAngles = new Vector3(0, 180, 0);

        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
           // sprite.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");
        }
       
        if (isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        //check for distance between player and enemy
        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);

        if (distance > 2.0f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }


        //check which side is the player compared to the enemy

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        //  Debug.Log("Side : " + transform.name + "  " + direction.x);

        if (direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            //face right
            //   sprite.flipX = false;
           transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            //face left
           // sprite.flipX = true;
            transform.eulerAngles = new Vector3(0, 180, 0);

        }
    }

}


