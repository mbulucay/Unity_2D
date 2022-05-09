using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torque = 1f;

    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float normalSpeed = 20f;
    [SerializeField] float slowSpeed = 20f;


    SurfaceEffector2D surface;

    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surface = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Controller();
        Movement();
    }

    private void Movement(){

        if(Input.GetKey(KeyCode.UpArrow)){
            surface.speed = boostSpeed;
        }
        else if(Input.GetKey(KeyCode.DownArrow)){
            surface.speed = slowSpeed;
        }
        else{
            surface.speed = normalSpeed;
        }
    }


    private void Controller(){

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torque);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torque);
        }
    }
}
