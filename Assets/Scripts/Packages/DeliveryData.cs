using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryData : MonoBehaviour
{

    public enum Region
    {
        green = 0,
        yellow,
        red,
        blue
    };

    public Region region;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Package"))
        {
            if(other.gameObject.GetComponent<PackageData>().region == (int)region && other.gameObject.GetComponent<PackageData>().grabbed)
            {
                Debug.Log("Package entered");
                other.gameObject.GetComponent<PackageData>().misdelivered = true;
                //Destroy(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Package"))
        {
            if (other.gameObject.GetComponent<PackageData>().region == (int)region && other.gameObject.GetComponent<PackageData>().grabbed)
            {
                Debug.Log("Package exited");
                other.gameObject.GetComponent<PackageData>().misdelivered = false;
                //Destroy(other.gameObject);
            }
        }
    }
}
