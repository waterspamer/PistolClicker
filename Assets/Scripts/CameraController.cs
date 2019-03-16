using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float rotX;
    float rotY;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(.05f);
        transform.Rotate(-2f, 0, 0);
       // transform.Rotate(0, Random.Range(-3f, 3f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Delay());
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-4 * Time.deltaTime * 10, 0);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += new Vector3(4 * Time.deltaTime * 10, 0);

        }
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 3, Space.World);
            transform.Rotate(-Vector3.right * Input.GetAxis("Mouse Y") * 3, Space.Self);
        }
        
        

    }
}
