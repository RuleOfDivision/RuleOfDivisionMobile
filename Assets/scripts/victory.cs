using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victory : MonoBehaviour
{
    private bool waiting;
    public string nextLevel;
    public AudioSource gameplayMusic;
    // Start is called before the first frame update
    void Start()
    {
        gameplayMusic.Pause();
        waiting = false;
        Time.timeScale = 0f;
        StartCoroutine(waitabit());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey && waiting == true)
        {
            //SceneManager.LoadScene(nextLevel);
            PlayerPrefs.SetString("nextLevel", nextLevel);
            SceneManager.LoadScene("LoadingScreen");
        }
    }

    IEnumerator waitabit()
    {
        yield return new WaitForSecondsRealtime(1f);
        waiting = true;
    }
}
