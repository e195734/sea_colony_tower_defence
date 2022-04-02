using System.Text.Json;
using System.Collections.Generic;

using UnityEngine;
public class WaveManager
{
    private float wavePassedTime = 0f;
    private int wavePassedSecond = 0;
    private int currentWave = 0;
    private WaveManagerData.WaveDataSet waveDataSet;
    private List<WaveManagerData.Wave> wave;

    public WaveManager(string jsonStringWaveData)
    {
        this.waveDataSet = JsonSerializer.Deserialize<WaveManagerData.WaveDataSet>(jsonStringWaveData);
    }

    public void setWaveType(string type)
    {
        List<WaveManagerData.EnemySpawnData> enemySpawnData = waveDataSet.enemySpawnData;
        for (int i = 0;i < enemySpawnData.Count; i++)
        {
            if(enemySpawnData[i].gameType == type)
            {
                this.wave = enemySpawnData[i].wave;
            }
        }
    }

    

    public List<WaveManagerData.Enemy> getSpawnData(float passedTime)
    {
        this.wavePassedTime += passedTime;
        if (this.wavePassedTime - this.wavePassedSecond > 1f)
        {
            wavePassedSecond += 1;
            List<WaveManagerData.SpawnTable> spawnTable = this.wave[this.currentWave].spawnTable;
            for (int i = 0; i < spawnTable.Count; i++)
            {
                if (spawnTable[i].time == this.wavePassedSecond)
                {
                    return spawnTable[i].enemy;
                }
            }
        }
        return null;
    }

}