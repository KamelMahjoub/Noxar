using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCultist : Enemy,IDamageable
{

    public int Health { get; set; }

    public GameObject fireball;


    public override void Init()
    {
        base.Init();
        Health = 1;
        speed = 0;
    }


  
    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }

        Health--;
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");

            //spawn coin
            GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity) as GameObject;
            //change the value of the coin
            coin.GetComponent<Coin>().coins = base.coins;

        }
    }

   

    public void Attack()
    {
        Instantiate(fireball, pointA.position, Quaternion.identity);

    }
}


  

