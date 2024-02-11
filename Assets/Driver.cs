using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{
    float steerAmount;
    float moveAmount;
    [SerializeField]float steerSpeed = 50f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Slow")
        {
            moveSpeed = slowSpeed;
        }

        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
    }
}
