using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GameObject car;
    
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("Car");
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = car.transform.position + car.transform.rotation * offset;
        transform.rotation = car.transform.rotation;
    }
}
