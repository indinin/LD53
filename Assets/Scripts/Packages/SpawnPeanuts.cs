using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPeanuts : MonoBehaviour
{
    [SerializeField] GameObject particles;
    bool collided = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collided)
        {
            collided = true;
            Debug.Log("Landed");
            Instantiate(particles, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        collided = false;
    }
}
