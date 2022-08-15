using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnParticleCollision(GameObject other) {
        Debug.Log($"{name}: Im hit {other.gameObject.name}!");
        Destroy(this.gameObject);
    }
}
