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
    GameObject targets;
    int startReg, endReg;
    void Start()
    {
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
        if((transform.position - target.position).magnitude < 0.2f)
        {
            Destroy(this.gameObject);
        }
    }

    int GetStartPoint()
    {
        return startReg * 4 + Random.Range(0, 4);
    }

    int GetTarget()
    {
        return endReg * 4 + Random.Range(0, 4);
    }
}
