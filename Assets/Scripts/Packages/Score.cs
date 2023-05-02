using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int score = 0;
    public float suspicion = 0;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Title"))
        {
            Destroy(this.gameObject);
        }
        if(suspicion >= 100)
        {
            DontDestroyOnLoad(this.gameObject);
            SceneManager.LoadScene("GameOver");
            suspicion = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
