using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetMoneysOnMenu : MonoBehaviour
{
    public TextMeshProUGUI texty;
    // Start is called before the first frame update
    void Start()
    {
        texty.text = PlayerPrefs.GetInt("MoneyDubloonies").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
