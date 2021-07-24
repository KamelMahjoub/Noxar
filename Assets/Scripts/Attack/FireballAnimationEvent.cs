using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAnimationEvent : MonoBehaviour
{
    //handle to the firecultist

    private FireCultist _fireCultist;


    public void Start()
    {
        //assign handle to the fire cultist
        _fireCultist = transform.parent.GetComponent<FireCultist>();

    }

    public void Fire()
    {
        //use handle to call Attack method on fire cultist
        _fireCultist.Attack();

    }
}
