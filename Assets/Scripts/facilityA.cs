using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facilityA : MonoBehaviour
{
    private float lastBulletFireElapsedTime = 0;
    private float fireInterval = 1;
    private HP hp = new HP(10);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.lastBulletFireElapsedTime += Time.deltaTime;
        if(lastBulletFireElapsedTime >= fireInterval)
        {
            lastBulletFireElapsedTime -= fireInterval;
            Instantiate((GameObject)Resources.Load("Harpoon"), transform.position, Quaternion.identity);
        }
        
    }
}
