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
    protected GameObject HPBar;

    // Start is called before the first frame update
    void Start()
    {
        this.fireInterval = 1;
        this.hp = new HP(10);
        this.targettingRadius = 10;
        this.HPBar = Instantiate((GameObject)Resources.Load("HPBar"),
                                 transform.position,
                                 Quaternion.identity);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            int atk = collision.gameObject.GetComponent<Enemy>().getAttack();
            this.hp.damage(atk);
            this.HPBar.gameObject.GetComponent<HPBar>().updateHP(this.hp.getHPRatio());
        }
        if (isDeath())
        {
            Destroy(this.gameObject);
        }
    }

    private bool isDeath()
    {
        return this.hp.isZero();
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

    private void OnDestroy()
    {
        Destroy(this.HPBar.gameObject);
    }
}
