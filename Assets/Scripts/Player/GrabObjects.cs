using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float maxGrabDistance = 5f,minGrabDistance = 2f;
    [SerializeField]
    private Transform objectHolder;
    [SerializeField]
    private Transform objectHolderStart;
    [SerializeField]
    private float speed = 100f;
    [SerializeField]
    private float lerpSpeed = 10f;
    [SerializeField]
    private float distance;
    [SerializeField]
    private GameObject movableObject;
    [SerializeField]
    float throwForce = 5f;

    [SerializeField]
    private Rigidbody grabbedRB;

    private string[] tags = {
        "Package",
        "Envelope"
    };

    void Update()
    {
        distance = Vector3.Distance(cam.transform.position, objectHolder.transform.position);

        if(grabbedRB)
        {
            if(distance >= minGrabDistance && distance <= maxGrabDistance)
            {
                objectHolder.transform.position = objectHolder.transform.position;// + cam.transform.forward * speed * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel");
            }
            else if (distance < minGrabDistance)
            {
                objectHolder.transform.position = objectHolder.transform.position + cam.transform.forward;
            }
            else
            {
                objectHolder.transform.position = objectHolder.transform.position - cam.transform.forward;
            }

            grabbedRB.velocity = (objectHolder.transform.position - movableObject.transform.position) * lerpSpeed;
        }

        //Drop
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(grabbedRB)
            {
                grabbedRB.useGravity = true;
                grabbedRB.freezeRotation = false;

                grabbedRB = null;
                movableObject = null;

                objectHolder.transform.position = objectHolderStart.transform.position;
            }
            else
            {
                RaycastHit hit;
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                if(Physics.Raycast(ray, out hit, maxGrabDistance))
                {
                    movableObject = hit.collider.gameObject;
                    if (tags.Contains(hit.collider.gameObject.tag))
                    {
                        grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
                    }
                    if(grabbedRB)
                    {
                        grabbedRB.useGravity = false;
                        grabbedRB.freezeRotation = true;
                        
                        if (grabbedRB.isKinematic)
                        {
                            grabbedRB = null;
                        }
                    }
                }
            }
        }

        //Throw
        if (Input.GetMouseButtonDown(0) && grabbedRB)
        {
            grabbedRB.useGravity = true;
            grabbedRB.freezeRotation = false;

            grabbedRB.velocity = (grabbedRB.gameObject.transform.position - cam.transform.position).normalized * throwForce;

            grabbedRB = null;
            movableObject = null;

            objectHolder.transform.position = objectHolderStart.transform.position;
        }
    }
}
