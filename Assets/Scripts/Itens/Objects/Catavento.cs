using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Catavento : MonoBehaviour
{
    public float speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(2 * speed,0,0);
    }
}
