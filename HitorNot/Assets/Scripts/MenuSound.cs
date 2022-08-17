using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    private static GameObject instance;
    public AudioSource Sound;

    // Start is called before the first frame update
    void Start()
    {
       // Sound = GetComponent<AudioSource>();//
        Sound.volume = PlayerPrefs.GetFloat("MenuMusic");
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        Sound.volume = PlayerPrefs.GetFloat("MenuMusic");
    }
}
