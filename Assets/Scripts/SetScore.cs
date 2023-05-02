using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SetScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Score: " + GameObject.Find("Score").GetComponent<Score>().score.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
