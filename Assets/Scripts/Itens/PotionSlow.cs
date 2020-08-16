using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSlow : MonoBehaviour
{
    public GameObject slowPool;

    Rigidbody rb;
    public float speed;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.isStatic)
        {
            Instantiate(slowPool, transform.position, slowPool.transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void TakeImpulse(GameObject target)
    {
        rb.useGravity = true;
        transform.SetParent(null);
        transform.LookAt(target.transform);
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}
