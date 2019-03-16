using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(-20, 20, 0) * Time.deltaTime * 6000);
        rb.AddRelativeTorque(new Vector3(6, 1, 5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
