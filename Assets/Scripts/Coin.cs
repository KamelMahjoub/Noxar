using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coins = 1;
    public AudioSource coinAudio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            Player player = collision.GetComponent<Player>();

            if (player != null)
            {
                player.AddCoins(coins);
                StartCoroutine(DestroyCoinRoutine());
       
            }
        }
    }


    IEnumerator DestroyCoinRoutine()
    {
        coinAudio.Play();
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }

}
