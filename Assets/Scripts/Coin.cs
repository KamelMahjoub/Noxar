using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coins = 1;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            Player player = collision.GetComponent<Player>();

            if (player != null)
            {
                player.AddCoins(coins);
                Destroy(this.gameObject);
            }



        }
    }
}
