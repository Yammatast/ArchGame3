using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooting : MonoBehaviour
{
    public int damagePerShot = 10;
    public float timeBewteenBullets = 0.15f;
    public float range = 100f;

    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectDisplayTime = 0.2f;

    void Awake()
    {
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();

    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBewteenBullets)
        {
            Shoot();
        }

        if (timer >= timeBewteenBullets * effectDisplayTime)
        {
            DisableEffects();

        }
    }

    void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    void Shoot()
    {
        timer = 0f;
        gunAudio.Play();

        gunLight.enabled = true;
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast (shootRay, out shootHit, range))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
               enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }

    }
}
