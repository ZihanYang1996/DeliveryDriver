using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Detected!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package") 
        {
            Debug.Log("Pacakage Picked Up!");
        }
        else if (other.tag == "Customer")
        {
            Debug.Log("Package Delivered!");
        }
    }
}
