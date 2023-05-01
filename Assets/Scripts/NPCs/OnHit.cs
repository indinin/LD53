using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour
{
    [SerializeField] AudioClip scream;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scream()
    {
        source.Stop();
        source.volume = 0.5f;
        source.clip = scream;
        source.loop = false;
        source.Play();
    }
}
