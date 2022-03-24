using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    private float wavePassedTime = 0;
    private WaveManager waveManager;



    // Start is called before the first frame update
    void Start()
    {
        string jsonString = (Resources.Load("wavesData", typeof(TextAsset)) as TextAsset).text;
        this.waveManager = new WaveManager(jsonString);
        this.waveManager.setWaveType("default");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        wavePassedTime += Time.deltaTime;
        List<WaveManagerData.Enemy> spawnData = this.waveManager.getSpawnData(Time.deltaTime);
        if (spawnData != null)
        {
            spawnEnemy(spawnData);
        }
    }
    
    private void spawnEnemy(List<WaveManagerData.Enemy> enemies)
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            WaveManagerData.Enemy enemy = enemies[i];
            for(int j = 0; j < enemy.enemyCount; j++)
            {
                Instantiate(createSpawnEnemyObject(enemy.enemyName),
                            getSpawnPosition(),
                            Quaternion.identity);
            }

        }
    }

    private Vector2 getSpawnPosition()
    {
        return new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized * 10;
    }

    private GameObject createSpawnEnemyObject(string name)
    {
        return (GameObject)Resources.Load(name);
    }
}
