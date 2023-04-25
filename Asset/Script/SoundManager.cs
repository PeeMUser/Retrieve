using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource hit;
    public AudioSource missed;
    public AudioSource Dashing;
    // Start is called before the first frame update
    void Start()
    {
        hit = gameObject.AddComponent<AudioSource>();
        missed = gameObject.AddComponent<AudioSource>();
        Dashing = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
