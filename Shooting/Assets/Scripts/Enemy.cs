using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject particleExplode;
    [SerializeField] GameObject particleHitByLaser;
    [SerializeField] Transform parent;
    [SerializeField] int point = 1;
    [SerializeField] int health = 100;

    ScoreBoard scoreBoard;

    [SerializeField] int hitDamage = 10;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (health <= 0){
            KillEnemy();     
        }

    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate(particleHitByLaser, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        health -= hitDamage;
        scoreBoard.IncreaseScore(point);
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(particleExplode, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }


}
