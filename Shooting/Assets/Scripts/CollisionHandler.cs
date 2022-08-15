using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadingTime = 1f;
    [SerializeField] ParticleSystem particle;

    private void OnTriggerEnter(Collider other) {
        Debug.Log(this.name + " Collided with " + other.gameObject.name);
        
        StartCrashSequence();
    }

    void StartCrashSequence()
    {   
        particle.Play();
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadLevel", loadingTime);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
