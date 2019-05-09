using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 30;
    public int currentHealth;
    public AudioClip deathClip;
    public float sinkSpeed = 2.5f;

    AudioSource enemyAudio;
    //ParticleSystem hitParticales;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;


    void Awake()
    {
        enemyAudio = GetComponent<AudioSource>();
        //hitParticales = GetComponent<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int amount, Vector3 hitPoints)
    {
        if (isDead)
        {
            return;
        }

        enemyAudio.Play();
        currentHealth -= amount;
       // hitParticales.transform.position = hitPoints;
      //  hitParticales.Play();

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        enemyAudio.clip = deathClip;
        enemyAudio.Play();

        StartSinking();

    }

    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;

        Destroy(gameObject, 2f);

    }
}
