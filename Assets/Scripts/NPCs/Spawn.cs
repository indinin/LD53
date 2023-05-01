using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject[] NPCs;

    float count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if(count >= 3)
        {
            Instantiate(NPCs[Random.Range(0, NPCs.Length)]);
            count = 0;
        }
    }
}
