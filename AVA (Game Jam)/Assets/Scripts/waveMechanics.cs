using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

//yes i know this code is utter dog shite i wrote it 
//on 3 hours sleep at 11 at night the next day

public class waveMechanics : MonoBehaviour
{
    // Start is called before the first frame update
    public int waveDelay = 30;

    public GameObject[] easyEnemies;
    public GameObject[] mediumEnemies;
    public GameObject[] hardEnemies; 
    // public waterWaveChance = 0.15f;
    // public airWaveChance = 0.15f;
    // public groundWaveChance = 0.15f
    private int nEasyEnemies;
    private int nMedEnemies;
    private int nHardEnemies;
    void Start()
    {
        nEasyEnemies = 25;
        nMedEnemies = 10;
        nHardEnemies = 0;
    }

    // Update is called once per frame
    float waveTimer = 0f;
    int waveNumber = 1;
    float waveSepperation = 40f;
    float nextEntityTimer = 0.5f;
    int currentWaveEntitiesAdded = 0;
    GameObject[] currentWaveEnemies;
    void Update()
    {
        if(waveTimer <= 0f) {
            currentWaveEnemies = generateWave();
            currentWaveEntitiesAdded = 0;
            waveTimer = waveSepperation; 
        } else {
            waveTimer -= Time.deltaTime;
        }

        if(nextEntityTimer <= 0 && currentWaveEntitiesAdded < currentWaveEnemies.Length) {
            Vector3 startingPosition = new Vector3(0,0,0);

            if(currentWaveEnemies[currentWaveEntitiesAdded].GetComponent<followPathScript>().enemyType == 0) {
                nextEntityTimer = 0.5f;
                startingPosition = GameObject.FindWithTag("GameController").GetComponent<GameMaster>().airWaypoints[0].transform.position;
            } else if(currentWaveEnemies[currentWaveEntitiesAdded].GetComponent<followPathScript>().enemyType == 1) {
                nextEntityTimer = 2f;
                startingPosition = GameObject.FindWithTag("GameController").GetComponent<GameMaster>().groundWaypoints[0].transform.position;
            } else if(currentWaveEnemies[currentWaveEntitiesAdded].GetComponent<followPathScript>().enemyType == 2) {
                nextEntityTimer = 2f;
                startingPosition = GameObject.FindWithTag("GameController").GetComponent<GameMaster>().riverWaypoints[0].transform.position;
            } 

            Instantiate(currentWaveEnemies[currentWaveEntitiesAdded], startingPosition, Quaternion.Euler(-90,0,0));
            currentWaveEntitiesAdded++;
        } else {
            nextEntityTimer -= Time.deltaTime;
        }

        nEasyEnemies+=7;
        nMedEnemies+=3;
        if(waveNumber % 5 == 0) {
            nHardEnemies++;
            waveSepperation += 3f;
        }
        waveSepperation += 0.5f*7 + 2f*3;
    }

    GameObject[] generateWave() {
        // GameObject[] waveEnemies;
        // // decide wave type
        // // and populate "waveEnemies" with the enemies that could appear in this wave
        // Random rnd = new Random();
        // float gameTypeRandNum = rnd.Next(0,1);
        // if(gameTypeRandNum <= waterWaveChance) { 
        //     /*waterwave*/ 
        //     waveEnemies = new GameObject[waterEnemies.Length];  
        //     waterEnemies.CopyTo(waveEnemies, 0);    
        // }
        // else if(waterWaveChance < gameTypeRandNum <= waterWaveChance + airWaveChance) { 
        //     /*airwave*/ 
        //     waveEnemies = new GameObject[airEnemies.Length];  
        //     airEnemies.CopyTo(waveEnemies, 0);    
        // }
        // else if(waterWaveChance + airWaveChance < gameTypeRandNum <= waterWaveChance + airWaveChance + groundWaveChance) { 
        //     /*groundwave*/ 
        //     waveEnemies = new GameObject[groundEnemies.Length];  
        //     groundEnemies.CopyTo(waveEnemies, 0);    
        // }
        // else { 
        //     /*waterwave*/ 
        //     waveEnemies = new GameObject[waterEnemies.Length + airEnemies.Length + groundEnemies.Length];  
        //     waterEnemies.CopyTo(waveEnemies, 0);  
        //     groundEnemies.CopyTo(waveEnemies, waterEnemies.Length);
        //     airEnemies.CopyTo(waveEnemies, waterEnemies.Length + groundEnemies.Length);

        // }

        GameObject[] spawnList = new GameObject[nEasyEnemies + nMedEnemies + nHardEnemies];
        System.Random rand = new System.Random();
        // for(int i = 0; i < nEasyEnemies; i++) { spawnList[i] = easyEnemies[rand.Next(easyEnemies.Length)]; }
        // for(; i < i + nMedEnemies; i++) { spawnList[i] = mediumEnemies[rand.Next(mediumEnemies.Length)]; }
        // for(; i < i + nHardEnemies; i++) { spawnList[i] = hardEnemies[rand.Next(hardEnemies.Length)] }

        int easyAdded = 0;
        int medAdded = 0;
        int hardAdded = 0;

        while(easyAdded < nEasyEnemies || medAdded < nMedEnemies || hardAdded < nHardEnemies) {
            double chooserRand = rand.NextDouble();
            if(chooserRand < 0.33 && hardAdded < nHardEnemies) {
                spawnList[easyAdded + medAdded + hardAdded] = hardEnemies[rand.Next(hardEnemies.Length)];
                hardAdded++;
            } else if(chooserRand < 0.66 && medAdded < nMedEnemies) {
                spawnList[easyAdded + medAdded + hardAdded] = mediumEnemies[rand.Next(mediumEnemies.Length)];
                medAdded ++;
            } else if(easyAdded < nEasyEnemies){
                spawnList[easyAdded + medAdded + hardAdded] = easyEnemies[rand.Next(hardEnemies.Length)];
                easyAdded ++;
            }
        }

        return spawnList;
    }

}