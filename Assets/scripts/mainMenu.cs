using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartTutorial()
    {
        Debug.Log("Tutorial");
        PlayerPrefs.SetString("nextLevel", "tutorial3");
        SceneManager.LoadScene("LoadingScreen");
        //SceneManager.LoadScene("tutorial1");
    }

    public void StartNewGame()
    {
        Debug.Log("new game");
        //SceneManager.LoadScene("SampleScene");
        PlayerPrefs.SetString("nextLevel", "SampleScene");
        SceneManager.LoadScene("LoadingScreen");
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
