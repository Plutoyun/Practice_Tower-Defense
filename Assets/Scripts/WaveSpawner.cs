using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public static int EnemiesAlive = 0; // Amount of exist enemies

    public Wave[] waves;

    public Transform spawnPoint; // Start point
    public Gamemanger gameManager;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f; //第一波敌人 time before first wave

    public Text waveCountdownText; // Display

    private int waveIndex = 0;

     void Update()
    {
        if (Gamemanger.GameIsOver) // if game finished
        {
            return;
        }
        if (EnemiesAlive > 0) // if there are enemies
        {
            return;
        }

        if (waveIndex == waves.Length) // if all waves has been destroyed
        {
            gameManager.WinLevel();
            //Debug.Log("LEVEL WON");
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave()); 
            //SpawnWave();
           // timeBetweenWaves += waveIndex;
            countdown = timeBetweenWaves + waveIndex;
            return;
        }

        

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.0}",countdown); //Mathf.Floor(countdown).ToString();//向下取整；Round down
    }

    IEnumerator SpawnWave()  //集合访问器 ； 多线程 Collection accessor; multi-threaded Generate waves
    {
       
        PlayerStats.Rounds++; // Number of current round

        Wave wave = waves[waveIndex]; 

        EnemiesAlive = wave.count; // how many enemies in this wave

        for (int i = 0; i < wave.count; i++) // Generate enemies according to wave's generation speed
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;

      
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy,spawnPoint.position,spawnPoint.rotation);//实例化pref Instantiate enemy
    }
}

