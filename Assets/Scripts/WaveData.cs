using System.Collections.Generic;
namespace WaveManagerData
{
    public class Enemy
    {
        public string enemyName { get; set; }
        public int enemyCount { get; set; }
        public string spawnAlgorism { get; set; }
    }

    public class SpawnTable
    {
        public int time { get; set; }
        public List<Enemy> enemy { get; set; }
    }

    public class Wave
    {
        public string name { get; set; }
        public int duration { get; set; }
        public List<SpawnTable> spawnTable { get; set; }
    }

    public class EnemySpawnData
    {
        public string gameType { get; set; }
        public List<Wave> wave { get; set; }
    }

    public class WaveDataSet
    {
        public List<EnemySpawnData> enemySpawnData { get; set; }
    }
}