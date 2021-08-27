using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    private Player _player;

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _player = collision.GetComponent<Player>();

        for(int i = 0; i<6;i++)
            _player.Damage();
        }
    }
}
