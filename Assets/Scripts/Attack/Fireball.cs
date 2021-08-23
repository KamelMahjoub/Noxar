using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    //destroy this after 3 seconds

    public void Start()
    {
        Destroy(this.gameObject, 5.0f);
    }

    //move right at 3m per second 
    private void Update()
    {
        transform.Translate(Vector3.left * 8 * Time.deltaTime);
    }


    //detect player and deal damage(IDamageable Interface)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IDamageable hit = collision.GetComponent<IDamageable>();


            if (hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
    }

}
