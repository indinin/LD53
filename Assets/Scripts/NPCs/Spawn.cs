using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject[] NPCs;

    float count = 10;//Random.Range(9f,12f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count -= Time.deltaTime;
        if(count <= 0)
        {
            Instantiate(NPCs[Random.Range(0, NPCs.Length)]);
            count = Random.Range(9f,12f);
        }
    }
}
