using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [SerializeField] GameObject followingObject;


    void LateUpdate()
    {
        transform.position = followingObject.transform.position + new Vector3(0, 0, -10);
    }
}
