using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coins : MonoBehaviour
{
    public GameObject RoundMan;
    private int coinsAm;
    public TextMeshProUGUI amount;
    public TextMeshProUGUI reachedLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        coinsAm = RoundMan.GetComponent<RoundManager>().rounds * 3;
        amount.text = "+" + coinsAm;
        reachedLevel.text = "Du nådde nivå " + RoundMan.GetComponent<RoundManager>().rounds;
        PlayerPrefs.SetInt("MoneyDubloonies", PlayerPrefs.GetInt("MoneyDubloonies") + coinsAm);
        Debug.Log(PlayerPrefs.GetInt("MoneyDubloonies"));
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
