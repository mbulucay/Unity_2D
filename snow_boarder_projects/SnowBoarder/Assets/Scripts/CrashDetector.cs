using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadSec = 0.5f;

    void OnTriggerEnter2D(Collider2D other) {

        Debug.Log("Failed");
        Invoke("ReloadScene", reloadSec);
    
    }

    void ReloadScene(){
        SceneManager.LoadScene(0);
    }

}
