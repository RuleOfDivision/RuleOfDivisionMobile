using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shopScript : MonoBehaviour
{
    public int playermoney;

    // test
    public GameObject shopMenu;
    public GameObject preMenu;
    // test end 
    void Start()
    {
        playermoney = PlayerPrefs.GetInt("MoneyDubloonies");
    }


    public void BuySkin(int skinName, int price)
    {
        if(playermoney - price >= 0)
        {
            char[] sb = PlayerPrefs.GetString("ownedSkins").ToCharArray();
            sb[skinName] = '1';
            string newString = new string (sb);
            PlayerPrefs.SetString("ownedSkins", newString);
            //playermoney -= price;
            PlayerPrefs.SetInt("MoneyDubloonies", PlayerPrefs.GetInt("MoneyDubloonies") - price);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //! Make this not boot you back to the very start of the menu. It's confusing for the player
            //test
            preMenu.SetActive(false);
            shopMenu.SetActive(true);
            //test end

            PlayerPrefs.Save();
        }
        
    }

    public void EquipSkin(int selectedSkin)
    {
        PlayerPrefs.SetInt("selSkin", selectedSkin);
    }
}
