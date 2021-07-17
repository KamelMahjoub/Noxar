using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    //variable to determine if the damage function can be called(cd)
    private bool _canDamage = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit :" + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            //if  can attack
            hit.Damage();
            //set that variable to false
            _canDamage = false;
            StartCoroutine(ResetDamage());
        }
    }

    //coroutine to reset variable after some time
    private IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5F);
        _canDamage = true;
    }
}
