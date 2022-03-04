using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate((GameObject)Resources.Load("EnemyA"),new Vector3(Random.value * 10 - 5, Random.value * 10 - 5, Random.value * 10- 5),Quaternion.identity);
    }
}
