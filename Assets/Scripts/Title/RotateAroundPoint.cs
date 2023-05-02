using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private Vector3 rotationPoint;
    [SerializeField]
    private Vector3 rotationAxis;

    void Update()
    {
        this.gameObject.transform.RotateAround(rotationPoint, rotationAxis, rotationSpeed * Time.deltaTime);
    }

    public void setRotationSpeed(float rotationSpeed)
    {
        this.rotationSpeed = rotationSpeed;
    }
}
