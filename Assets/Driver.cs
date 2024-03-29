using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{
    float steerAmount;
    float moveAmount;
    [SerializeField] float steerSpeed = 50f;
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
        steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; // Multiply by Time.deltaTime to make the movement frame rate independent
        moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // Multiply by Time.deltaTime to make the movement frame rate independent

        transform.Translate(0, moveAmount, 0);
        if (moveAmount > 0)
        {
            transform.Rotate(0, 0, -steerAmount);
        }
        else if (moveAmount < 0)
        {
            transform.Rotate(0, 0, steerAmount);
        }
        

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Slow")
        {
            StartCoroutine(SpeedChange(moveSpeed, slowSpeed, 3f));
        }

        if (other.tag == "Boost")
        {
            StartCoroutine(SpeedChange(moveSpeed, boostSpeed, 3f));
        }
    }

    IEnumerator SpeedChange(float defaultSpeed, float tempSpeed, float duration)
    {
        moveSpeed = tempSpeed;
        yield return new WaitForSeconds(duration);
        moveSpeed = defaultSpeed;
    }
}
