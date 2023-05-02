using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnPeanuts : MonoBehaviour
{
    [SerializeField] GameObject particles;
    bool collided = false;
    Rigidbody rb;
    Vector3 prevVelocity = Vector3.zero;
    PackageData data;
    MeshRenderer render;
    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        render = GetComponent<MeshRenderer>();
        data = GetComponent<PackageData>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!render.enabled && !source.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        prevVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {



        if (!collided)
        {
            collided = true;
            data.SoftHitSound();
            //Debug.Log("Landed");
            //Instantiate(particles, transform.position, Quaternion.identity);
        }

        if (collision.gameObject.tag.Equals("NPC"))
        {
            GameObject NPC = collision.gameObject;
            //NPC.GetComponent<WalkToPointNavMesh>().Hit(transform.position);
            NPC.GetComponent<WalkToPointNavMesh>().enabled = false;
            NPC.GetComponent<NavMeshAgent>().enabled = false;
            NPC.AddComponent<Rigidbody>();
            NPC.GetComponent<Rigidbody>().AddExplosionForce(1000, transform.position, 100);
            //Destroy(collision.gameObject);
            data.HardHitSound();
            Instantiate(particles, transform.position, Quaternion.identity);
            NPC.GetComponent<OnHit>().Scream();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            //Destroy(this.gameObject);
        }else if (prevVelocity.magnitude > .75f)
        {
                Instantiate(particles, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        collided = false;
    }
}
