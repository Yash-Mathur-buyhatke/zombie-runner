using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;
    [System.Serializable]
    private class AmmoSlot{
        public AmmoType ammoType;
        public int amount;
    }
    public int GetTotalAmmos(AmmoType ammoType){
        Debug.Log(GetAmmoSlot(ammoType).amount);
        return GetAmmoSlot(ammoType).amount;

    }
    public void AmmoReducer(AmmoType ammoType){
        GetAmmoSlot(ammoType).amount--;

    }
    public void AmmoIncreaser(AmmoType ammoType,int amount){
        GetAmmoSlot(ammoType).amount+=amount;

    }
    private AmmoSlot GetAmmoSlot(AmmoType ammoType){
        Debug.Log("freer");
        foreach (AmmoSlot slot in ammoSlots){
            if(slot.ammoType == ammoType){
                Debug.Log(slot.amount);
                return slot;
            }
        }
        return null;
    }
}
