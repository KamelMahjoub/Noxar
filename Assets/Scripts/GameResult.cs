using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{


    private Player _player;

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _player = collision.GetComponent<Player>();

            if (_player != null)
            {
                UIManager.Instance.ShowGameLevelCompletePanel();
            }

        }
    }
}
