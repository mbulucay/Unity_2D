using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float bootSpeed = 30f;
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed;
        steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

    }

    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
        Debug.Log("Speed Decreased");
    }



    void OnTriggerEnter2D(Collider2D other) {

        Debug.Log("Speed Increased");

        if(other.tag == "Boost"){
            moveSpeed = bootSpeed;
        }
    }


}
