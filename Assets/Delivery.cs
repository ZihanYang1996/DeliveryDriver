using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0.5f;
    bool havePackage = false;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Detected!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !havePackage) 
        {  
            Debug.Log("Pacakage Picked Up!");
            havePackage = true;
            Destroy(other.gameObject, destroyDelay);
        }
        if (other.tag == "Customer" && havePackage)
        {
            Debug.Log("Package Delivered!");
            havePackage = false;
        }
    }
}
