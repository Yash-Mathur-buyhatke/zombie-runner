using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentWeapon : MonoBehaviour
{
    [SerializeField]
    Camera FPSCamera;

    [SerializeField]
    float range = 200f;

    [SerializeField]
    float damage = 30f;

    [SerializeField]
    ParticleSystem muzzleFlash;

    [SerializeField]
    AudioClip gunSound;

    [SerializeField]
    Ammo ammoSlot;

    [SerializeField]
    AmmoType ammoType;

    [SerializeField]
    GameObject hitEffect;
    AudioSource audio;

    void PlayMuzzleFlash()
    {
        if (!muzzleFlash.isPlaying)
            muzzleFlash.Play();
    }

    void Shoot()
    {
        Debug.Log("Going to shoot");
        if (ammoSlot.GetTotalAmmos(ammoType) > 0)
        {
            if (!audio.isPlaying)
            {
                audio.PlayOneShot(gunSound);
            }
            else
            {
                if (audio.isPlaying)
                {
                    audio.Stop();
                    audio.PlayOneShot(gunSound);
                }
            }
            ammoSlot.AmmoReducer(ammoType);
            PlayMuzzleFlash();
            RaycastHit hit;
            Physics.Raycast(
                FPSCamera.transform.position,
                FPSCamera.transform.forward,
                out hit,
                range
            );
            createHitEffectVfx(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
                return; // means hitting something else not an enemy

            target.TakeDamage(damage);
            Debug.Log(hit.transform.name);
        }
    }

    // Update is called once per frame
    void Start()
    {
        
        // sound = Resources.Load<AudioClip>("gunSound");
        audio = GetComponent<AudioSource>();
        muzzleFlash.enableEmission = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            Shoot();
        }
    }

    void createHitEffectVfx(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
