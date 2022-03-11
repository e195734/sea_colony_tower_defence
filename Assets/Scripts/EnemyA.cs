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
            this.transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            this.transform.rotation = Quaternion.FromToRotation(-Vector3.right, target.transform.position - this.transform.position);
        }
    }
    private bool isDeath()
    {
        return this.hp.isZero();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Colony")||collision.CompareTag("Bullet"))
        {
            this.hp.damage(5);
        }
        if (isDeath())
        {
            Destroy(this.gameObject);
        }
    }
}
