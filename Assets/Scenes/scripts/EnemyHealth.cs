using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    float health = 100f;

    [SerializeField] AudioClip deathSound;
    AudioSource audio;
    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //Destroy(gameObject);
            Debug.Log("enemy died");
            if (!isDead)
            {
                //GetComponent<Animator>().SetBool("dead",true);
                isDead = true;
                if (!audio.isPlaying)
                {
                    audio.PlayOneShot(deathSound);
                }
                else
                {
                    if (audio.isPlaying)
                    {
                        audio.Stop();
                        audio.PlayOneShot(deathSound);
                    }
                }
                GetComponent<Animator>().SetTrigger("die");
            }
            else
            {
                return;
            }
        }
    }
}
