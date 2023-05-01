using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPackage : MonoBehaviour
{
    [SerializeField] GameObject[] packages;
    [SerializeField]  Material[] mats;
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
        counter += Time.deltaTime;

        if(counter >= 5)
        {
            Spawn();
            counter = 0;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        int spot = Random.Range(0, 16);
        GameObject spawn = Instantiate(packages[Random.Range(0,3)], transform.position, Quaternion.identity);
        spawn.GetComponent<PackageData>().region = spot / 4;
        //spawn.GetComponent<MeshRenderer>().materials[1].color = colors[Random.Range(0, 4)];
        GameObject targets = GameObject.Find("Targets");
        GameObject tar = targets.transform.GetChild(spot).gameObject;
        Vector3 target = tar.transform.position;
        spawn.transform.position = new Vector3(target.x, target.y + 0.4f, target.z);
        tar.GetComponent<AudioSource>().clip = spawnSound;
        tar.GetComponent<AudioSource>().Play();
    }
}
