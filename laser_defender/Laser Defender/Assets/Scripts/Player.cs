using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float left_padding = 1f;
    [SerializeField] float right_padding = 1f;
    [SerializeField] float top_padding = 1f;
    [SerializeField] float bottom_padding = 1f;


    Vector2 minBound;
    Vector2 maxBound;

    Vector2 rawInput;

    void Start() {
        InitBounds();    
    }

    void Update()
    {
        movePlayer();
    }

    void InitBounds(){

        Camera camera = Camera.main;
        
        minBound = camera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = camera.ViewportToWorldPoint(new Vector2(1, 1));
    
    }

    private void movePlayer()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBound.x + left_padding, maxBound.x - right_padding);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBound.y + bottom_padding, maxBound.y  - top_padding);

        transform.position = newPos;
    }

    void OnMove(InputValue key){
        rawInput = key.Get<Vector2>();
        Debug.Log(rawInput);
        Debug.Log("rawInput");

    }


}
