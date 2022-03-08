using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour
{
    private HP hp = new HP(5);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
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
