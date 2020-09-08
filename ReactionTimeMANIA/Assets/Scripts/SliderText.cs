using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour
{
    public Slider slide;
    public string sayso;
    private Text tex;

    // Start is called before the first frame update
    void Start()
    {
        
        tex = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        tex.text = sayso + slide.value.ToString();
    }
}
