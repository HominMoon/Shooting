using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject Explode;
    [SerializeField] GameObject particleHitByLaser;
    [SerializeField] GameObject parentGameObject;
    [SerializeField] int point = 1;
    [SerializeField] int health = 100;

    ScoreBoard scoreBoard;

    [SerializeField] int hitDamage = 10;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("Spawn");
        AddRigidBody();
    }

    private void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (health <= 0)
        {
            KillEnemy();
        }

    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate(particleHitByLaser, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        health -= hitDamage;
        
    }

    void KillEnemy()
    {
        GameObject fx = Instantiate(Explode, transform.position, Quaternion.identity);
        fx.transform.parent = parentGameObject.transform;
        scoreBoard.IncreaseScore(point);
        Destroy(gameObject);
    }


}
