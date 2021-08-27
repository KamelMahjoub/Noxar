using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    [SerializeField] 
    private Transform targetA, targetB;

    private float speed = 2f; //speed of elevation
    [SerializeField]
    private bool switching = false;


    void Update()
    {
        if (transform.position == targetB.position)
        {
            switching = true;
        }
        else if (transform.position == targetA.position)
        {
            switching = false;
        }


        if (!switching)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetB.position, speed * Time.deltaTime);
        }
        else if (switching)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetA.position, speed * Time.deltaTime);
        }

       
    }
}
