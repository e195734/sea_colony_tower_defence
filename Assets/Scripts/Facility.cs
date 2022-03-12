using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facility : MonoBehaviour
{
    protected float lastBulletFireElapsedTime = 0;
    protected float fireInterval;
    protected HP hp;
    protected GameObject target;
    protected float targettingRadius;

    // Start is called before the first frame update
    void Start()
    {
        this.fireInterval = 1;
        this.hp = new HP(10);
        this.targettingRadius = 10;
    }

    void FixedUpdate()
    {
        this.lastBulletFireElapsedTime += Time.deltaTime;
        if (lastBulletFireElapsedTime >= fireInterval)
        {
            lastBulletFireElapsedTime -= fireInterval;
            getNearestTarget();
            fireing();
        }

    }

    private void getNearestTarget()//����͈͂ň�ԋ߂��G�����b�N�B��{�I�ɂ̓��b�N�͈�x������ƊO��Ȃ��B
    {
        float tmpMinDistance = this.targettingRadius;
        GameObject tmpMinObject = null;
        if (!this.target)
        {
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject obj in enemys)
            {
                float tmpDistance = Vector3.Distance(transform.position, obj.transform.position);
                if (tmpMinDistance > tmpDistance)
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
