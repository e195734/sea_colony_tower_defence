using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    private float wavePassedtime = 0;
    private float waveInterval = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        wavePassedtime += Time.deltaTime;
        if(wavePassedtime >= waveInterval)
        {
            wavePassedtime -= waveInterval;
            waveInit();
        }
    }

    private void waveInit()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate((GameObject)Resources.Load("EnemyA"),
                        new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized * 5,
                        Quaternion.identity);
        }
    }
}
