using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mangyRoundMgr : MonoBehaviour
{
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
    void Newround()
    {
        List<int> randHealthList = GetComponent<endless_mode>().MasterRandomizer(rounds);
            placeholderFloat = randHealthList[0];
            Debug.Log("Newround: " + 0);
            Vector3 targetPos = positionsList[0];
            GameObject curEnemy = Instantiate(enemyPrefab, targetPos, Quaternion.identity);
            curEnemy.GetComponent<enemyHealth>().health = placeholderFloat;
            curEnemy.GetComponent<enemyHealth>().target = 2;
            curEnemy.GetComponent<enemyHealth>().roundManager = gameObject;

            //health
            //!gogogogogo curEnemy.GetComponent<enemyHealth>().manager = manager;
            curEnemy.GetComponent<enemyHealth>().wrongmath = wrongMath;
            curEnemy.GetComponent<enemyHealth>().phoneUI = phoneUI;
            //!curEnemy.GetComponent<enemyHealth>().UI = UI;
            curEnemy.GetComponent<enemyHealth>().reason = reasonText;
            curEnemy.GetComponent<enemyHealth>().player = playerLoc.gameObject;
            //move
            curEnemy.GetComponent<enemyMove>().playerLocation = playerLoc;
            curEnemy.GetComponent<enemyMove>().Canvas = canvas;
    }
}
