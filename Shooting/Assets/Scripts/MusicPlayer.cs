using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        int musicNums = FindObjectsOfType<MusicPlayer>().Length;

        if (musicNums > 1)
        {
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }

    }
}
