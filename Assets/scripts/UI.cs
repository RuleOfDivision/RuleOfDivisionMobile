using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    public Image hearts;
    public Sprite[] heartSprites;
    public int health;
    public int EnemyTargetHealth;
    public int amountOfEnemies;
    public int deadEnemies;
    //public TextMeshProUGUI enemiesLeftText;
    public GameObject gameOver;
    public GameObject victoryScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Update()
    {
        //enemiesLeftText.text = deadEnemies + "/" + amountOfEnemies;
        if(health == 0)
        {
            Lose();
        }

        if(deadEnemies == amountOfEnemies)
        {
            win();
        }
    }

    public void DecreaseHearts()
    {
        //Debug.Log("Gaming");
        health -= 1;
        if(health < 0)
        {
            health = 0;
        }
        hearts.sprite = heartSprites[health];
    }

    public void enemyDefeated()
    {
        deadEnemies += 1;
    }

    public void Lose()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOver.SetActive(true);
    }

    public void win()
    {
        victoryScreen.SetActive(true);
    }
}
