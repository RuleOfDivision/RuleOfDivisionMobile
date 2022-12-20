using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemyHealth : MonoBehaviour
{
    public TextMeshPro Text;
    public float health;
    private Quaternion newrot;
    public Transform textPoint;
    public GameObject manager;
    public float target;
    public GameObject deadprefab;
    public GameObject wrongmath;
    public GameObject phoneUI;
    public GameObject UI;

    private float original;
    private float result;
    private float divider;
    private string explanation;
    public TextMeshProUGUI reason;

    public GameObject roundManager;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        newrot = Text.transform.rotation;
        //target = manager.GetComponent<UI>().EnemyTargetHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Text.transform.rotation = newrot;
        Text.transform.position = textPoint.position;
        Text.text = health.ToString();
        if(health == target)
        {
            Instantiate(deadprefab, transform.position, Quaternion.identity);
            //UI.GetComponent<UI>().enemyDefeated();
            roundManager.GetComponent<RoundManager>().defeatedEnemy();
            //!fix
            Debug.Log("here");
            player.GetComponent<playermove>().ReturntMin();
            
            Destroy(gameObject);
        }

        if(health < target || (health % 1) != 0 )
        {
            phoneUI.SetActive(false);
            wrongmath.SetActive(true);
            if(health < target)
            {
                explanation = " är mindre än målet.";
            }
            else if((health % 1) != 0)
            {
                explanation = " är inte ett heltal.";
            }
            reason.text = original.ToString() + " / " + divider.ToString() + " = " + result.ToString() + explanation;
        }
    }

    public void takeDamage(float dmg)
    {
        original = health;
        health /= dmg;
        result = health;
        divider = dmg;
    }
}
