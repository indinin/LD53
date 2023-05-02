using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvData : MonoBehaviour
{
    [SerializeField] public int region = -1;
    [SerializeField] Color[] colors;
    bool grabbed = false;

    public void SetColor()
    {
        if (!grabbed)
        {
            grabbed = true;
            int color = Random.Range(0, 4);
            while (color == region)
                color = Random.Range(0, 4);
            region = color;
            GetComponent<MeshRenderer>().material.color = colors[color];
        }
    }
}
