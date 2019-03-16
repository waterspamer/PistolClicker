using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int _score;
    public int _health;
    public bool _lost;
    public GameObject _target;
    public List<GameObject> spawnPoints;
    public Text healthScore;
    public AudioSource a;
    public AudioClip brigada;

    // Start is called before the first frame update
    void Start()
    {
        //brigada = GetComponent<AudioClip>();
       // a.clip = brigada;
        
        _score = 0;
        _health = 4;
        _lost = false;
        
        StartCoroutine(Spawner(1));
        a.Play();
    }

   

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator Spawner(float t)
    {
        int s = Random.Range(0, 11);
        Instantiate(_target, spawnPoints[s].transform);
        yield return new WaitForSeconds(t);
        t -= 0.005f;
        StartCoroutine(Spawner(t));
    }

    // Update is called once per frame
    void Update()
    {

        healthScore.text = "Health : " + _health;
        if (_health < 1)
        {
            healthScore.text = "YOU LOST";
            healthScore.color = Color.red;
            StartCoroutine(Restart());
        }
    }
}
