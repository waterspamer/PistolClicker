using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int health;
    public Text he;
    // Start is called before the first frame update
    void Start()
    {
        health = 4;

    }

    // Update is called once per frame
    void Update()
    {
        he.text = "HEALTH : " + health.ToString();
    }
}
