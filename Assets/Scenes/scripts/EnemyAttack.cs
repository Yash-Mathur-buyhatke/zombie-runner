using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerHealth target;
   [SerializeField] float playerDamage = 20f;
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent(){
        if(target==null){
            return;
        }
        target.TakeDamage(playerDamage);
        Debug.Log("Damaging");
    }
}
