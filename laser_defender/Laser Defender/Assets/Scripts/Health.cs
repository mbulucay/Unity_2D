using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        DamageDealer dealer = other.GetComponent<DamageDealer>();

        if(dealer != null){
            TakeDamage(dealer.getDamage());
            dealer.Hit();
        }
    }

    void TakeDamage(int damage){
        health -= damage;

        if(health <= 0){
            Destroy(gameObject);
        }
    }

}
