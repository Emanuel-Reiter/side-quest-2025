using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject splash_on;
    public GameObject splash_off;

    public void Start()
    {
        splash_on.SetActive(false);
        splash_off.SetActive(true);
    }

    public void StartGame()
    {
        splash_on.SetActive(true);
        splash_off.SetActive(false);
        StartCoroutine(MenuCorroutine());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private IEnumerator MenuCorroutine()
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene("Level_01_Scene");
    }
}
