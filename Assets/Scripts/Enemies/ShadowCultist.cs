using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCultist : Enemy,IDamageable
{
    public int Health { get; set; }
    public override void Init()
    {
        base.Init();
        //assign health to enemy health
        Health = base.health;

    }


    //check distance between the enemy and the player

    public override void Movement()
    {
        base.Movement();
    }

    public void Damage()
    {

        if (isDead == true)
        {
            return;
        }
        
        //substract 1 from health 
        Health--;

        anim.SetTrigger("Hit");
        //freeze
        isHit = true;
        //in combat
        anim.SetBool("InCombat", true);

        //if health is less than 1 
        //destroy the object 
        if (Health < 1)
        {
            isDead = true;

            anim.SetTrigger("Death");

            //spawn diamon,d
           // GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            //change the value of the diamond 
            //diamond.GetComponent<Diamond>().gems = base.gems;
        }

    }

}




