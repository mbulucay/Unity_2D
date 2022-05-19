using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hifEffect;
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        DamageDealer dealer = other.GetComponent<DamageDealer>();

        if(dealer != null){
            TakeDamage(dealer.getDamage());
            playHitEffect();
            dealer.Hit();
        }
    }

    void TakeDamage(int damage){
        health -= damage;

        if(health <= 0){
            Destroy(gameObject);
        }
    }

    void playHitEffect(){
        if(hifEffect != null){
            ParticleSystem instance = Instantiate(hifEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
