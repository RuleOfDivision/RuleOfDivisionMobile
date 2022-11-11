using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public class endless_mode : MonoBehaviour
{

    //det här skriptet skrevs av Max Wasserman.

    //todo put enemX in an array
    public List<int> factors;
    public List<int> values;
    public int enem0 = 0;
    public int enem1 = 0;
    public int enem2 = 0;
    public int enem3 = 0;

    //difficulty balancing-----------------------------------
    bool spaceHeld = false;
    public float scale = 1;
    public float maxNumFloat;
    public int maxNum = 10; //todo: Make these variables better balanced given the round number
    public float minNumFloat;
    public int minNum = 2;
    public float quotient = 2f;
    //-------------------------------------------------------------------


    int RandomizeX(int enemX)
    {
        //the idea is to store the multiplication table of 2 and randomize the chosen index.
        int chosenInt;
        System.Random rnd = new System.Random();
        //don't question the (int)
        chosenInt = rnd.Next((int)minNumFloat / 2, (int)maxNumFloat / 2);
        if (chosenInt < 2) { chosenInt = 2; }
        enemX = 2 * chosenInt;
        //huh, guess i need to return a value too...
        //Debug.Log("from randomize" + enemX);

        return enemX;

    }
    public bool IsPrime(int enemX) //looks like i needed you after all
    {
        if (enemX <= 1) return false;
        if (enemX == 2) return true;
        if (enemX % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(enemX));

        for (int i = 3; i <= boundary; i += 2)
            if (enemX % i == 0)
                return false;

        return true;
    }
    public bool GiveNums(int enemX)
    {
        int b;
        //2b = enemX?
        for (b = 1; b <= enemX && enemX >= 19; b++) //make sure enemX isnt too low when trying this because otherwise no values would be returned on the first rounds of endless mode.
        {
            if (enemX % b == 0)
            {
                Console.WriteLine(b + " is a factor of " + enemX);
                factors.Add(b);
            }
            else
                return false;
        }
        foreach (int factor in factors) //todo replace this with whatever you do to a list
        {// if 1 or more factors of enemX are prime, randomize again else, return true
            IsPrime(factor);
            if (IsPrime(factor)) { RandomizeX(enemX); }
            else
                return true;
        }
        return false;

    }

    //todo make masterrandom return an array of enem values int[] enemyValues;
    public List<int> MasterRandomizer(int round)
    {
        float flRound = (float)round;//again, dont ask

        //* for balancing------------------------------------------
        if (flRound <= 30f)
        {
            scale = 1.04f;
        }
        if (flRound >= 30f && round <= 40f)
        {
            scale = 1.02f;
        }
        if (flRound >= 40f)
        {
            scale = 1.007f;
        }
        maxNumFloat = maxNumFloat * scale;
        minNumFloat = minNumFloat * scale;
        Debug.Log((int)minNumFloat + "Min and max Floats" + (int)maxNumFloat);



        //Debug.Log(maxNumFloat + " a " + minNumFloat);
        enem0 = RandomizeX(enem0);
        enem1 = RandomizeX(enem1);
        enem2 = RandomizeX(enem2);
        enem3 = RandomizeX(enem3);
        //Debug.Log("wtf" + enem0 + "," + enem1 + "," + enem2 + "," + enem3);

        //got here-----------------

        //this checks if all enem can be divided into the goal quotient, if not, it rolls again
        //Then it checks if it's divisible
        if (GiveNums(enem0) == false)
        {
            RandomizeX(enem0);
        }


        if (GiveNums(enem1) == false)
        {
            RandomizeX(enem1);
        }

        if (GiveNums(enem2) == false)
        {
            RandomizeX(enem2);
        }

        if (GiveNums(enem3) == false)
        {

            RandomizeX(enem3);
        }
        if(enem0 == enem1 && enem0 == enem3 ){
            enem0 +=2;
        }
        if(enem0 == enem2 && enem1 == enem2 ){
            enem2 +=2;
        }
        if(enem1 == enem3 && enem2 == enem3){
            enem3 += 2;
        }

        //Debug.Log("Created new numbers:");
        var output = new List<int>() { enem0, enem1, enem2, enem3 };
        //Debug.Log("enem0, " + enem0 + " enem1, " + enem1 + " enem2, " + enem2 + " enem3, " + enem3);
        Debug.Log(output[0] + ", " + output[1] + ", " + output[2] + ", " + output[3] + ", ");

        return output; // enemyValues;

    }

    // Use this for initialization
    void Awake()
    {
        Debug.Log("started endless mode");
        maxNumFloat = maxNum;
        minNumFloat = minNum;

    }
    void Update()
    {
        /* testing
        */
        //the only thing that works -----------------------
        if (Input.GetKeyDown("space") && spaceHeld == false)
        {
            MasterRandomizer(1);
            spaceHeld = true;
        }
        if (Input.GetKeyDown("space") == false && spaceHeld == true)
        {
            spaceHeld = false;
        }
    }

}

