using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facilityA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate((GameObject)Resources.Load("Harpoon"),transform.position, Quaternion.identity);
    }
}