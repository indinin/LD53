using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                score.score += 1;
                Destroy(this.gameObject);
            }
        }
    }
}
