using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour
{
    private int damage;
    private int speed = 3;
    private float lifeTime = 0;
    private float lifeTimeLimit = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position -= this.transform.right * Time.deltaTime * speed;
        this.lifeTime += Time.deltaTime;
        if (lifeTime >= this.lifeTimeLimit)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
