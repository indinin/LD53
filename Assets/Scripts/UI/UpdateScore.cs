using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score.score + "\nSuspicion: " + score.suspicion.ToString("0");
    }
}
