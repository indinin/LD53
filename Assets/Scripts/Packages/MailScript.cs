using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MailScript : MonoBehaviour
{
    [SerializeField] AudioClip doneClip;
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("entered collision");
        if (collision.gameObject.tag.Equals("Mailbox"))
        {
            GameObject box = collision.gameObject.transform.parent.gameObject;
            if((int)box.GetComponent<DeliveryData>().region == gameObject.GetComponent<EnvData>().region)
            {
                box.GetComponent<AudioSource>().clip = doneClip;
                box.GetComponent<AudioSource>().Play();
                score.score += 2;
                Destroy(this.gameObject);
            }
        } else if (collision.gameObject.tag.Equals("NPC"))
        {
            GameObject NPC = collision.gameObject;
            //NPC.GetComponent<WalkToPointNavMesh>().Hit(transform.position);
            NPC.GetComponent<WalkToPointNavMesh>().enabled = false;
            NPC.GetComponent<NavMeshAgent>().enabled = false;
            NPC.AddComponent<Rigidbody>();
            NPC.GetComponent<Rigidbody>().AddExplosionForce(1000, transform.position, 100);
            //Destroy(collision.gameObject);
            NPC.GetComponent<OnHit>().Scream();
            Destroy(this.gameObject);
        }
    }
}
