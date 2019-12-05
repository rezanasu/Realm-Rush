using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitpoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitpoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        ParticleSystem deathInstance = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        deathInstance.Play();
       
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitpoints--;
        hitParticlePrefab.Play();
    }
}
