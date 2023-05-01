using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPackage : MonoBehaviour
{
    [SerializeField] GameObject[] packages;
    [SerializeField]  Material[] colors;
    // Start is called before the first frame update
    void Start()
    {
        GameObject spawn = Instantiate(packages[0], transform.position, Quaternion.identity);
        spawn.GetComponent<MeshRenderer>().materials[1] = colors[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
