using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private GameObject Target;
    [SerializeField] private GameObject Pistol;
    Vector3 RelPosition;
    [SerializeField] private Camera cam ;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RelPosition = Pistol.transform.localPosition;
    }
    // Update is called once per frame
    void Update()
    {
        Pistol.transform.localPosition = new Vector3(Pistol.transform.localPosition.x, RelPosition.y, RelPosition.z);
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {       
                Pistol.transform.localPosition = new Vector3(-1.7f, RelPosition.y, RelPosition.z);
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Pistol.transform.localPosition = new Vector3(0.9f, Pistol.transform.localPosition.y, Pistol.transform.localPosition.z);

        }
        
    }
}
