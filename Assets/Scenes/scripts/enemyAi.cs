using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAi : MonoBehaviour
{
    [SerializeField]
    AudioClip attackSound;
    AudioSource audio;

    [SerializeField]
    float chaseRange = 45f;
    bool isAttackSoundPlaying = false;
    [SerializeField]
    Transform target;
    NavMeshAgent navMeshAgent;
    EnemyHealth health;
    float distanceToTarget = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        health = GetComponent<EnemyHealth>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75f);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        else
        {
            distanceToTarget = Vector3.Distance(target.position, transform.position);
            if (distanceToTarget <= navMeshAgent.stoppingDistance)
            {
                // attack target
                if (audio.isPlaying)
                {
                    
                }
                else
                {
                    audio.PlayOneShot(attackSound);
                }
                GetComponent<Animator>().SetBool("attack", true);
            }
            else
            {
                if (distanceToTarget <= chaseRange)
                {
                    GetComponent<Animator>().SetBool("attack", false);
                    GetComponent<Animator>().SetTrigger("move");
                    navMeshAgent.SetDestination(target.position);
                }
                else
                {
                    GetComponent<Animator>().SetTrigger("idle");
                }
            }
        }
    }
}
