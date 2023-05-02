using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnvelopes : MonoBehaviour
{
    [SerializeField] GameObject envelope;
    [SerializeField] Material[] mats;
    [SerializeField] Color[] colors;
    [SerializeField] AudioClip spawnSound;
    float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        counter += Time.deltaTime;

        if (counter >= Random.Range(10f, 15f))
        {
            Spawn();
            counter = 0;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Spawn();
        }
        */
    }

    public void Spawn()
    {
        int spot = Random.Range(0, 16);
        GameObject spawn = Instantiate(envelope, transform.position, Quaternion.identity);
        spawn.GetComponent<EnvData>().region = spot / 4;
        GameObject targets = GameObject.Find("Mailboxes");
        GameObject tar = targets.transform.GetChild(spot).gameObject;
        Vector3 target = tar.transform.position;
        spawn.transform.position = new Vector3(target.x + 0.1f, target.y + 0.1f, target.z);
        tar.GetComponent<AudioSource>().clip = spawnSound;
        tar.GetComponent<AudioSource>().Play();
    }
}
