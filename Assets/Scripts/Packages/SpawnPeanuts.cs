using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

        if (collision.gameObject.tag.Equals("NPC"))
        {
            GameObject NPC = collision.gameObject;
            NPC.GetComponent<NavMeshAgent>().enabled = false;
            NPC.AddComponent<Rigidbody>();
            NPC.GetComponent<Rigidbody>().AddExplosionForce(100, transform.position, 100);
            //Destroy(collision.gameObject);
            Instantiate(particles, transform.position, Quaternion.identity);
            NPC.GetComponent<OnHit>().Scream();
            Destroy(this.gameObject);
        }

        if (!collided)
        {
            collided = true;
            //Debug.Log("Landed");
            //Instantiate(particles, transform.position, Quaternion.identity);
        }

        if(GetComponent<Rigidbody>().velocity.magnitude > .75f)
        {
            
            {
                Instantiate(particles, transform.position, Quaternion.identity);
                //Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        collided = false;
    }
}
