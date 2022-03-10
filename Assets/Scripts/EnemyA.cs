using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour
{
    private HP hp = new HP(5);
    private float speed = 1f;
    private GameObject target = null;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Colony");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }
    private bool isDeath()
    {
        return this.hp.isZero();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.hp.damage(5);
        if (isDeath())
        {
            Destroy(this.gameObject);
        }
    }
}
