using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    bool toSpawn;
    //Rigidbody rb;
    public GameObject a;
    public float lifeTime;
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(.5f);
        toSpawn = false;
        a = GameObject.Find("GameManagerr");
        yield return new WaitForSeconds(2);
        gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
        StartCoroutine(Die());
    }
    IEnumerator Die()
    {
       
        yield return new WaitForSeconds(0.5f);
        var c = a.GetComponent<GameController>();
        c._health -= 1;
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<GameObject>();
        //rb = GetComponent<Rigidbody>();
        toSpawn = true;
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if (toSpawn) transform.position += new Vector3(0, 10 * Time.deltaTime, 0);
    }
}
