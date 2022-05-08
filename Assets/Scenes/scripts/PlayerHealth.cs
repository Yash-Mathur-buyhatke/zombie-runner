using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField] float health=100f;
    bool isDead = false;
    public bool IsDead(){
        return isDead;
    }
    public void TakeDamage(float damage){
        health-=damage;
        if(health<=0){
            //Destroy(gameObject);
            GetComponent<DeathHandler>().HandleDeath();
            
            
        }
    }
}
