using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopItem : MonoBehaviour
{
    public int item;
    public int price;
    public GameObject mainScript;
    public GameObject buyButton;
    public GameObject equipButton;
    // Start is called before the first frame update
    void Start()
    {
        char[] sb = PlayerPrefs.GetString("ownedSkins").ToCharArray();
        if(sb[item] == '1')
        {
            buyButton.SetActive(false);
            equipButton.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buy()
    {
        mainScript.GetComponent<shopScript>().BuySkin(item, price);
        Debug.Log(PlayerPrefs.GetInt("MoneyDubloonies"));
    }

    public void equip()
    {
        mainScript.GetComponent<shopScript>().EquipSkin(item);
    }
}
