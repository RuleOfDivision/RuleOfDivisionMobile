using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundManager : MonoBehaviour
{
    // targeting system
    public GameObject player;
    //
    public GameObject enemyPrefab;
    private float placeholderFloat = 4;
    public Vector3[] positionsList;
    public int rounds;
    public int enemiesleft;

    //variables to be assigned to enemy
    
    //health
    public GameObject manager;
    public GameObject wrongMath;
    public GameObject UI;
    public GameObject phoneUI;
    public TextMeshProUGUI reasonText;
    public TextMeshProUGUI levelText; 

    //move

    public Transform playerLoc;
    public GameObject canvas;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            newRound();
        }

        if(enemiesleft < 1)
        {
            rounds += 1;
            enemiesleft = 4;
            newRound();
        }

        if(rounds > 0)
        {
            //Debug.Log("SUS");
            levelText.text = "Nivå: " + rounds;
        }
        
    }

    void newRound()
    {
        Debug.Log("Round " + rounds);
        
        //GetNumbers(bla bla);
        for (int i = 0; i < 4; i++)
        {
            List<int> randHealthList = GetComponent<endless_mode>().MasterRandomizer(rounds);
            placeholderFloat = randHealthList[i];
            Debug.Log("Newround: " + i);
            Vector3 targetPos = positionsList[i];
            GameObject curEnemy = Instantiate(enemyPrefab, targetPos, Quaternion.identity);
            curEnemy.GetComponent<enemyHealth>().health = placeholderFloat;
            curEnemy.GetComponent<enemyHealth>().target = 2;
            curEnemy.GetComponent<enemyHealth>().roundManager = gameObject;

            //health
            curEnemy.GetComponent<enemyHealth>().manager = manager;
            curEnemy.GetComponent<enemyHealth>().wrongmath = wrongMath;
            curEnemy.GetComponent<enemyHealth>().phoneUI = phoneUI;
            curEnemy.GetComponent<enemyHealth>().UI = UI;
            curEnemy.GetComponent<enemyHealth>().reason = reasonText;
            //move
            curEnemy.GetComponent<enemyMove>().playerLocation = playerLoc;
            curEnemy.GetComponent<enemyMove>().Canvas = canvas;

            // targeting system
            //player.GetComponent<playermove>().enemies[i] = curEnemy.transform;
            Debug.Log("here");
            //playerReference.GetComponent<PlayerMoveScriptName>().yourlistnamehere [i] = curEnemy.transform;

        }
    }

    public void defeatedEnemy()
    {
        enemiesleft -= 1;
        Debug.Log("defeated enemy");
    }
}
