using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject joystick;
    public GameObject attackButton;
    public GameObject numberSwitcher;
    public GameObject currentNum;
    public bool paused;
    public bool pleasePause;

    private void Start()
    {
        joystick.SetActive(true);
        attackButton.SetActive(true);
        numberSwitcher.SetActive(true);
        currentNum.SetActive(true);
    }

    void PauseFunction()
    {
        //idea is to display the play button when paused and vice versa
    }
}
