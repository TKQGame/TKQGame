using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public Transform[] spawnPoint;
    
    public Transform parent;
    public float curTimeToSpawn;
    public float timeToSpawn;
    public int[] kstEnemy;

    public bool isReloaded;
    public float curWaveReloading;
    public float waveReloadingTime;
    private int pointer = 0;
    public bool ready;
    public GameObject readyPanel;

    public Text waveText;
    public Text killstText;

	void Start () {
        kstEnemy[pointer] = kstEnemy[pointer];
    }
	
	void Update () {

        
        waveText.text = "Wawe " + pointer + " / " + kstEnemy.Length;
        killstText.text = "Spawned mobs to finish: " + kstEnemy[pointer].ToString();
        curTimeToSpawn -= Time.deltaTime;
        curWaveReloading -= Time.deltaTime;
        if (curWaveReloading <= 0)
        {
            isReloaded = true;
            if (curTimeToSpawn <= 0 && kstEnemy[pointer] > 0 && isReloaded==true )
            {
                Spawn();
                curTimeToSpawn = timeToSpawn;
                kstEnemy[pointer]--;
                if(kstEnemy[pointer]==0)
                {
                    readyPanel.SetActive(true);
                    isReloaded = false;
                    
                }
            }

        }
	}


    public void Spawn()
    {
        int rnd = Random.Range(0, spawnPoint.Length);
       /* switch (pointer)
        {
            case 0:
                enemyPrefab.GetComponent<EnemySkript>().healthEnemy += enemyPrefab.GetComponent<EnemySkript>().healthEnemy * 1.25f;
                break;
            case 1:
                enemyPrefab.GetComponent<EnemySkript>().healthEnemy += enemyPrefab.GetComponent<EnemySkript>().healthEnemy * 1.35f;
                break;
            case 2:
                enemyPrefab.GetComponent<EnemySkript>().healthEnemy += enemyPrefab.GetComponent<EnemySkript>().healthEnemy * 1.5f;
                break;
            case 3:
                enemyPrefab.GetComponent<EnemySkript>().healthEnemy += enemyPrefab.GetComponent<EnemySkript>().healthEnemy * 1.7f;
                break;
            case 4:
                enemyPrefab.GetComponent<EnemySkript>().healthEnemy += enemyPrefab.GetComponent<EnemySkript>().healthEnemy * 2f;
                break;
        }*/
            
        Instantiate(enemyPrefab, spawnPoint[rnd].position, spawnPoint[rnd].rotation, parent);
    }

    public void Ready()
    {
        ready = true;
        ReloadingWave();
        readyPanel.SetActive(false);
        ready = false;
        isReloaded = true;
        pointer++;
    }
    void ReloadingWave()
    {
        
        if (curWaveReloading <= 0)
        {
            curWaveReloading = waveReloadingTime;
        }

    }
}
