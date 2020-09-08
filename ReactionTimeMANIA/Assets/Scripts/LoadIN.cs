using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SaveSystem;

public class LoadIN : MonoBehaviour
{
    [SerializeField] private GameObject RTMText;
    [SerializeField] private Transform GoTo;
    [SerializeField] private GameObject Ballas;
    [SerializeField] private Transform BallsPawn;
    [SerializeField] private Transform Settings;

    [SerializeField] private Transform CollSizer; private Slider collsizerslider;
    [SerializeField] private Transform Sizer;     private Slider sizerslider;
    [SerializeField] private Transform Speeder;   private Slider speederslider;
    [SerializeField] private Transform Frequencyx;private Slider frequencyslider;

    public AnimationCurve Curve;
    private int Spawned;
    public int hitty;
    public Text missed;
    public Text hit;
    public Text spawned;
    public KeyCode activate1;
    public KeyCode activate2;

    private float ttitty;


    public float collsize;
    public float size;
    public float speed;
    public float Frequency;

    
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.move(RTMText, GoTo.position, 2f).setEase(Curve);
        StartCoroutine(moveout());
        ttitty = Time.time + random();

        collsizerslider = CollSizer.GetComponent<Slider>();
        sizerslider = Sizer.GetComponent<Slider>();
        speederslider = Speeder.GetComponent<Slider>();
        frequencyslider = Frequencyx.GetComponent<Slider>();

        collsize = EasySave.Load<float>("collsize", 1f); collsizerslider.value = collsize;
        size = EasySave.Load<float>("size", 50);         sizerslider.value = size;
        speed = EasySave.Load<float>("speed", 50000);    speederslider.value = speed;
        Frequency = EasySave.Load<float>("frequency", 1);frequencyslider.value = Frequency;

    }

    // Update is called once per frame
    void Update()
    {
        Balls();
        CheckersLOL();
        missed.text = "Missed " + (Spawned - hitty);
        hit.text = "Hit " + hitty;
        spawned.text = "Spawned " + Spawned;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settings();
        }
        collsize = collsizerslider.value;
        size = sizerslider.value;
        speed = speederslider.value;
        Frequency = frequencyslider.value;

    }
    void Balls()
    {
        if (Time.time > ttitty)
        {
            
            Instantiate(Ballas, BallsPawn);
            ttitty = Time.time + random() * Frequency;
            Spawned++;
        }
    }
    void CheckersLOL()
    {
        if (Input.GetKeyDown(activate1))
        {
            print("b");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                print("ayy");
                Destroy(hit.transform.gameObject);
                hitty++;
            }
        }
    }
    IEnumerator moveout()
    {
        yield return new WaitForSeconds(2f);
        LeanTween.move(RTMText, GoTo.position - new Vector3(0, 999, 0), 0.5f).setEase(Curve);
    }
    float random()
    {
        return Random.Range(0.1f, 1f);
    }
    void settings()
    {
        print("yomom" + Settings.gameObject.activeInHierarchy);
        if(!Settings.gameObject.activeInHierarchy)
        {
            print("imdoinit");
            Settings.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            Settings.gameObject.SetActive(false);
            EasySave.Save("collsize", collsize);
            EasySave.Save("size", size);
            EasySave.Save("speed", speed);
            EasySave.Save("frequency", Frequency);
        }
    }
}
