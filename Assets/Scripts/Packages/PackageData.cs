using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageData : MonoBehaviour
{
    public int region = -1;
    [SerializeField] Color[] colors;
    public bool grabbed = false;
    public bool misdelivered = false;
    float count = 0;
    bool soundPlayed = false;
    [SerializeField] AudioClip hitSoft, hitHard, deliver;
    AudioSource source;
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (misdelivered)
        {
            count += Time.deltaTime;
            if (count >= 0.5f && !soundPlayed)
            {
                DeliverSound();
                soundPlayed = true;
            }
        } else if (count != 0)
        {
            count = 0;
        }

        if(soundPlayed && !source.isPlaying)
        {
            score.score += 1;
            Destroy(this.gameObject);
        }
    }

    public void SetColor()
    {
        if (!grabbed)
        {
            int col = Random.Range(0, 4);
            while (col == region)
            {
                col = Random.Range(0, 4);
            }
            region = col;
            GetComponent<MeshRenderer>().materials[1].color = colors[col];
            grabbed = true;
        }
    }

    void DeliverSound()
    {
        source.clip = deliver;
        source.Play();
    }

    public void SoftHitSound()
    {
        if (grabbed && !misdelivered)
        {
            source.clip = hitSoft;
            source.Play();
        }
    }

    public void HardHitSound()
    {
        if (grabbed)
        {
            source.clip = hitHard;
            source.Play();
        }
        
    }
    
}
