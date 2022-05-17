using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject Projectile;
    [SerializeField] float speed = 7f;
    [SerializeField] float lifetime = 5;
    [SerializeField] float fireRate = 0.3f;

    private bool isFire = false;

    Coroutine fireRutine;

    void Start()
    {
        
    }

    void Update()
    {
        Fire();
    }

    public void IsFire(bool fire){
        isFire = fire;
    }

    void Fire(){

        if(isFire && fireRutine == null){
            fireRutine = StartCoroutine(FireCont());
        }
        else if(!isFire && fireRutine != null){
            StopCoroutine(fireRutine);
            fireRutine = null;
        }
    }

    IEnumerator FireCont(){

        while(true){
            GameObject instance = Instantiate(Projectile, gameObject.transform.position, Quaternion.identity);

            Rigidbody2D rgb2d = instance.GetComponent<Rigidbody2D>();
            if(rgb2d != null){
                rgb2d.velocity = transform.up * speed;
            }

            Destroy(instance, lifetime);
            yield return new WaitForSeconds(fireRate);
        }

    }

}
