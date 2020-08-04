using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Catavento : MonoBehaviour
{
    public float speed = 4;
  
    public void Rotate()
    {
        transform.Rotate(2 * speed, 0, 0);
    }
}
