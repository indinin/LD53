using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkToPointNavMesh : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    [SerializeField] Transform target;
    bool set = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position - target.position).magnitude < 0.2f)
        {
            Destroy(this.gameObject);
        }
    }
}
