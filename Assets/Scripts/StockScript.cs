using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockScript : MonoBehaviour
{
    Rigidbody rb;
    Vector3 RelPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RelPosition = this.transform.localPosition;
    }

    IEnumerator Imitation()
    {
        this.transform.localPosition = new Vector3 (-2f, 0 ,0);
       
        yield return new WaitForSeconds(0.1f);
        rb.AddRelativeForce(new Vector3(7f, 0, 0) * Time.deltaTime * 1200);
        yield return new WaitForSeconds(.15f);
        if (Input.GetKeyUp(KeyCode.Mouse1))
        this.transform.localPosition = Vector3.zero;
        rb.Sleep();

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, RelPosition.y, RelPosition.z);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Imitation());
        }
    }
}
