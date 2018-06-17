using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Text waveCountDownText;

    public Transform spawnPoint;                // spawn position
    public float timeBetweenWaves = 5f;         // longer later

    public GamesManager gameManager;

    private float countdown = 2f;               // first wave time
    private int waveNumber = 0;                 // current wave ID

    void Update ()
    {
        if (EnemiesAlive > 0)
            return ;

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return; 
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave ()
    {
        PlayerStats.Rounds++;

        if (waveNumber == waves.Length)
        {
            if (EnemiesAlive == 0)
            {
                gameManager.WinLevel();
                this.enabled = false;
            }
        }
        else
        {
             Wave wave = waves[waveNumber];

            EnemiesAlive = wave.count;

            for (int i = 0; i < wave.count; i++)
            {
                SpawnEnemy(wave.enemy);
                yield return new WaitForSeconds(1f / wave.rate);
            }
            waveNumber++;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

}
