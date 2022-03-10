using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facilityA : MonoBehaviour
{
    private float lastBulletFireElapsedTime = 0;
    private float fireInterval = 1;
    private HP hp = new HP(10);
    GameObject target = null;
    private float targettingRadius = 10f;

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
            getNearestTarget();
            fireing();
        }
        
    }

    private void getNearestTarget()//特定範囲で一番近い敵をロック。基本的にはロックは一度かかると外れない。
    {
        float tmpMinDistance = this.targettingRadius;
        GameObject tmpMinObject = null;
        if (!this.target)
        {
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject obj in enemys)
            {
                float tmpDistance = Vector3.Distance(transform.position, obj.transform.position);
                if(tmpMinDistance > tmpDistance)
                {
                    tmpMinDistance = tmpDistance;
                    tmpMinObject = obj;
                }
            }
            this.target = tmpMinObject;
        }
    }

    private void fireing()
    {
        if (this.target)
        {
            Instantiate((GameObject)Resources.Load("Harpoon"), transform.position, Quaternion.FromToRotation(-Vector3.right, target.transform.position - this.transform.position));
        }
    }
}
