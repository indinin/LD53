using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject titleMenu;
    [SerializeField]
    private GameObject controlsMenu;
    [SerializeField]
    private GameObject goalMenu;

    // Start is called before the first frame update
    void Start()
    {
        titleMenu.SetActive(true);
        controlsMenu.SetActive(false);
        goalMenu.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void GoToTitleMenu()
    {
        titleMenu.SetActive(true);
        controlsMenu.SetActive(false);
        goalMenu.SetActive(false);
    }

    public void GoToControlsMenu()
    {
        titleMenu.SetActive(false);
        controlsMenu.SetActive(true);
        goalMenu.SetActive(false);
    }

    public void GoToGoalMenu()
    {
        titleMenu.SetActive(false);
        controlsMenu.SetActive(false);
        goalMenu.SetActive(true);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
