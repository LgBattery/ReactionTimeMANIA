using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BAWSA : MonoBehaviour
{
    private LoadIN Manager;
    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("MANAGER").GetComponent<LoadIN>();
        transform.localScale = new Vector3(Manager.size, Manager.size, Manager.size);
        gameObject.GetComponent<SphereCollider>().radius = Manager.collsize;
        transform.localEulerAngles = new Vector3(0, 0, Random.Range(5, -10));
        gameObject.GetComponent<Rigidbody>().AddForce(transform.right * -Manager.speed);
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
