using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PistolScript : MonoBehaviour
{
    Rigidbody rb;
    Rigidbody brb;
    public AudioSource a;
    public AudioClip shotSound;
    Vector3 RelPosition;
    Vector3 RelAimPosition;
    public GameObject BulSpawn;
    public Text ScoreText;
    public GameObject bullet;
    public GameObject shotPlace;
    
    int _score;
    public Light L;
    public GameObject Cracks;
    [SerializeField] private GameObject decal;
    
    public Camera cam;
    // Start is called before the first frame update

    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RelPosition = this.transform.localPosition;
        brb = bullet.GetComponent<Rigidbody>();
        a = GetComponent<AudioSource>();
        a.clip = shotSound;
        _score = 0;
        StartCoroutine(OnLoaded());
    }

    IEnumerator OnLoaded()
    {
        ScoreText.text = "Ready";
        yield return new WaitForSeconds(1f);
        ScoreText.text = "Set";
        yield return new WaitForSeconds(1f);
        ScoreText.text = "GO!";
        yield return new WaitForSeconds(1f);
    }

    IEnumerator Lighter(RaycastHit hit)
    {
        var g = Instantiate(L);
        g.transform.position = hit.point + hit.normal * 0.01f;
        g.transform.rotation = Quaternion.LookRotation(-hit.normal);
        yield return new WaitForSeconds(0.2f);
        Destroy(g);
    }

    IEnumerator Imitation()
    {
        this.transform.localPosition += new Vector3(0, 0, -.2f);
        Instantiate(bullet, BulSpawn.transform.position, bullet.transform.rotation);
        
        // bullet.transform.parent = null;
        yield return new WaitForSeconds(0.02f);
        rb.AddRelativeForce(new Vector3(.1f, 0, 0) * Time.deltaTime * 1200);
      
        yield return new WaitForSeconds(.1f);
        if (!Input.GetKeyUp(KeyCode.Mouse1))
        this.transform.localPosition = new Vector3 (transform.localPosition.x, RelPosition.y, RelPosition.z);
        rb.Sleep();

    }

    IEnumerator Rifle()
    {
        StartCoroutine(Imitation());
        a.Play();
        var ray = new Ray(shotPlace.transform.position, shotPlace.transform.forward * 300f);
        Debug.DrawRay(shotPlace.transform.position, shotPlace.transform.forward * 300f);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (!hit.transform.gameObject.CompareTag("Target"))
            {
                var g = Instantiate(decal);
                g.transform.position = hit.point + hit.normal * 0.01f;
                g.transform.rotation = Quaternion.LookRotation(-hit.normal);
                var l = new List<GameObject>();
                for (int i = 0; i < Random.Range(7, 19); i++)
                {
                    var a = Instantiate(Cracks);

                    a.transform.position = hit.point + hit.normal * 0.01f;
                    a.transform.rotation = Quaternion.LookRotation(hit.normal);
                    l.Add(a);
                    
                }
                foreach (var a in l)
                {
                    StartCoroutine(Destroy1(a));
                }
                for (int i = 0; i < l.Count; i++)
                {
                    var c = l[i].GetComponent<Rigidbody>();
                    c.AddForce(new Vector3(Random.Range(-3000f, 3000f), Random.Range(-3000f, 3000f), Random.Range(-3000f, 3000f)));
                }

            }

            if (hit.transform.gameObject.CompareTag("Target"))
            {
                var a = hit.transform.gameObject.GetComponent<TargetScript>();
                _score += (int)((float)1000 / a.lifeTime);
                Destroy(hit.transform.gameObject);
                ScoreText.text = ("SCORE : " + _score.ToString());
            }
            StartCoroutine(Lighter(hit));

        }
        brb.AddRelativeForce(new Vector3(-10, 0, 0) * Time.deltaTime * 1200);
        yield return new WaitForSeconds(0.12f);
        StartCoroutine( Rifle());
    }

    IEnumerator Destroy1(GameObject a)
    {
        yield return new WaitForSeconds(3);
        Destroy(a);
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0)) StartCoroutine(Rifle());
        //if (Input.GetKeyUp(KeyCode.Mouse0)) StopAllCoroutines(); 
      
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            a.Play();
            var ray = new Ray(shotPlace.transform.position, shotPlace.transform.forward * 300f);
            Debug.DrawRay(shotPlace.transform.position, shotPlace.transform.forward * 300f);
            RaycastHit hit;
            
            
            if (Physics.Raycast(ray, out hit))
            {
                if (!hit.transform.gameObject.CompareTag("Target"))
                {
                    StartCoroutine(Lighter(hit));
                    var g = Instantiate(decal);
                    
                    g.transform.position = hit.point + hit.normal * 0.01f;
                    g.transform.rotation = Quaternion.LookRotation(-hit.normal);
                    var l = new List<GameObject>();
                    for (int i = 0; i < Random.Range(7, 19); i++)
                    {
                        var a = Instantiate(Cracks);
                        
                        a.transform.position = hit.point + hit.normal * 0.01f;
                       a.transform.rotation = Quaternion.LookRotation(hit.normal);
                        l.Add(a);
                        
                    }
                    foreach (var a in l)
                    {
                        StartCoroutine(Destroy1(a));
                    }
                  for (int i = 0; i < l.Count; i++)
                    {
                        var c = l[i].GetComponent<Rigidbody>();
                        c.AddForce(new Vector3(Random.Range(-3000f, 3000f), Random.Range(-3000f, 3000f), Random.Range(-3000f, 3000f)));
                    }
                    
                }
                
                if (hit.transform.gameObject.CompareTag("Target"))
                {
                    var a = hit.transform.gameObject.GetComponent<TargetScript>();
                    _score += (int)((float)1000 / a.lifeTime);
                    Destroy(hit.transform.gameObject);
                    ScoreText.text = ("SCORE : " + _score.ToString());
                }
                
                
            }
            brb.AddRelativeForce(new Vector3(-10, 0, 0) * Time.deltaTime * 1200);
            StartCoroutine(Imitation());
        }
    }
}
