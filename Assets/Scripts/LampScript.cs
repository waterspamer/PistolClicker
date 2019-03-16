using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampScript : MonoBehaviour
{
    [SerializeField] private Light l;
    [SerializeField] private GameObject model;
    [SerializeField] private Material m1;
    [SerializeField] private Material m2;
    Color startColor;
    // Start is called before the first frame update
    float intensity;

    IEnumerator LightBug()
    {
        for (int i = 0; i < Random.Range(1, 4); i++)
        {
            l.intensity = 0;
            model.GetComponent<MeshRenderer>().material = m2;
            yield return new WaitForSeconds(Random.Range(0.05f, 0.2f));
            l.intensity = 2;
            model.GetComponent<MeshRenderer>().material = m1;
        }    
    }
    void Start()
    {
        intensity = l.intensity;
        startColor = l.color;
    }

    // Update is called once per frame
    void Update()
    {
        var a = Random.Range(0, 100);
        if (a  > 95)
        {
            StartCoroutine(LightBug());
        }
    }
}
