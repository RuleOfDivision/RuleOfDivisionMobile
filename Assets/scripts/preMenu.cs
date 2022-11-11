using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preMenu : MonoBehaviour
{
    public bool pressed;
    public Animator camAnim;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        if (!PlayerPrefs.HasKey("ownedSkins"))
        {
            PlayerPrefs.SetString("ownedSkins", "100000");
        }

        if (!PlayerPrefs.HasKey("MoneyDubloonies"))
        {
            PlayerPrefs.SetInt("MoneyDubloonies", 0);
        }

        if (!PlayerPrefs.HasKey("selSkin"))
        {
            PlayerPrefs.SetInt("selSkin", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.AltGr))
        {
            Debug.Log("set string");
            PlayerPrefs.SetString("ownedSkins", "100000");
            PlayerPrefs.SetInt("MoneyDubloonies", 10000);
            PlayerPrefs.SetInt("selSkin", 0);
        }
        if(Input.touchCount > 0)
        {
            pressed = true;
        }
        camAnim.SetBool("move", pressed);
        if (pressed)
        {
            gameObject.SetActive(false);
            Debug.Log(PlayerPrefs.GetInt("MoneyDubloonies"));
        }




    }
}
