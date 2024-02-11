using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool havePackage = false;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Detected!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package") 
        {
            Debug.Log("Pacakage Picked Up!");
            havePackage = true;
        }
        if (other.tag == "Customer" && havePackage)
        {
            Debug.Log("Package Delivered!");
            havePackage = false;
        }
    }
}
