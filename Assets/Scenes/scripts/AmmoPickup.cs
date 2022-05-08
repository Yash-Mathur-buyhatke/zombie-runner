using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int amountAmt = 5;
    [SerializeField] AmmoType ammoType;
    [SerializeField] GameObject objectHavingAmmoClass;
     private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            objectHavingAmmoClass.GetComponent<Ammo>().AmmoIncreaser(ammoType,amountAmt);
            Destroy(gameObject);
        }
    }
}
