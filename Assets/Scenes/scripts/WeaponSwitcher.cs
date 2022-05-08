using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeaponIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetNewWeapon();
    }

    void ProcessKeyInput(){
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            currentWeaponIndex = 0;
        } else if(Input.GetKeyDown(KeyCode.Alpha2)){
            currentWeaponIndex = 1;
        } else if(Input.GetKeyDown(KeyCode.Alpha3)){
            currentWeaponIndex = 2;
        }
    }
    void SetNewWeapon(){
        int weaponIndex = 0;
        
        foreach(Transform weapon in transform){
           
            if(weaponIndex == currentWeaponIndex){
                weapon.gameObject.SetActive(true);
            } else {
                 weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
    void ProcessScrollWheel(){
        if(Input.GetAxis("Mouse ScrollWheel")>0){
            if(currentWeaponIndex>=transform.childCount - 1){
                currentWeaponIndex = 0;
            } else {
                currentWeaponIndex++;
            }
        } else if(Input.GetAxis("Mouse ScrollWheel")<0){
            if(currentWeaponIndex>=transform.childCount - 1){
                currentWeaponIndex = 0;
            } else {
                currentWeaponIndex++;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        int previousWeaponIndex = currentWeaponIndex;
        ProcessKeyInput();
        ProcessScrollWheel();
        if(previousWeaponIndex!=currentWeaponIndex){
            SetNewWeapon();
        }

    }
}
