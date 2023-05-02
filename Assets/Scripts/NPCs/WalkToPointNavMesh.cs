using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkToPointNavMesh : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    [SerializeField] Transform target;
    public bool spotted = false; //true when the NPC catches the player;
    bool hit = false;
    Vector3 hitPoint = Vector3.zero;
    GameObject targets;
    int startReg, endReg;
    AudioSource source;
    [SerializeField] AudioClip gasp;
    GameObject player;
    Score score;

    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
        player = GameObject.FindGameObjectWithTag("Player");
        source = GetComponent<AudioSource>();
        targets = GameObject.Find("Targets");
        agent = GetComponent<NavMeshAgent>();
        startReg = Random.Range(0, 4);
        do
        {
            endReg = Random.Range(0, 4);
        } while (startReg == endReg);

        agent.transform.position = targets.transform.GetChild(GetStartPoint()).position;
        target = targets.transform.GetChild(GetTarget());
        agent.SetDestination(target.position);
        //targets.transform.GetChild(Random.Range(0, target.childCount - 1));
    }

    // Update is called once per frame
    void Update()
    {
        if (spotted)
        {
            score.suspicion += Time.deltaTime * 5;
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        }
        else if (hit)
        {
            hit = false;
            HitFinish(hitPoint);
        }
        else if ((transform.position - target.position).magnitude < 0.2f)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {

    }

    int GetStartPoint()
    {
        return startReg * 4 + Random.Range(0, 4);
    }

    int GetTarget()
    {
        return endReg * 4 + Random.Range(0, 4);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //Check if they're holding something
            if(other.gameObject.GetComponent<GrabObjects>().grabbedRB != null && !spotted)
            {
                
                spotted = true;
                agent.enabled = false;
                source.Stop();
                source.clip = gasp;
                source.loop = false;
                source.Play();
                //Destroy(this.gameObject);
            }
        }
    }

    public void Hit(Vector3 pos)
    {
        spotted = false;
        hit = true;
        hitPoint = pos;
    }

    public void HitFinish(Vector3 pos)
    {
        spotted = false;
        GetComponent<WalkToPointNavMesh>().spotted = false;
        GetComponent<NavMeshAgent>().enabled = false;
        gameObject.AddComponent<Rigidbody>();
        GetComponent<Rigidbody>().AddExplosionForce(100, pos, 100);
        GetComponent<OnHit>().Scream();
        this.enabled = false;
    }
}
