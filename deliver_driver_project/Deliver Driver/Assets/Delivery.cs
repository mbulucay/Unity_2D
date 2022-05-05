using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    bool hasPackage = false;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField] float destroySec = 0.5f;

    SpriteRenderer sprite;

    void Start(){
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = noPackageColor;
        
    }

    void OnCollisionEnter2D(Collision2D target){
        Debug.Log("Entered On COLLISION Enter");
    }

    void OnTriggerEnter2D(Collider2D target){

        if(target.tag == "Package" && !hasPackage){
            Debug.Log("Package Picked UP!!!");
            Destroy(target.gameObject, destroySec);
            sprite.color = target.gameObject.GetComponent<SpriteRenderer>().color;
            hasPackage = true;
        }

        if(target.tag == "Customer" && hasPackage){
            Debug.Log("Customer Take the package");
            sprite.color = noPackageColor;
            hasPackage = false;
        }

    }

    // void OnTriggerExit2D(Collider2D target){
    //     Debug.Log("Leave On TRIGGER exit");
    // }

}
