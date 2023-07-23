using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    Rigidbody rigid;
    public float MoveSpeed;
    public float BreakPower;
    public float RotateSpeed;
    public bool useRigidbody;
    public float RotateAmount;
    public float maxSpeed;
    public Gear gear = Gear.P;
    public Text td;
    public Text mstd;
    public AudioSource aso;
    public AudioClip speedover;
    public bool warn_playing;
    // Start is called before the first frame update
    void Start()
    {
        if (useRigidbody)
        {
            rigid = gameObject.GetComponent<Rigidbody>();
        }
        td = GameObject.Find("Speed").GetComponent<Text>();
        mstd = GameObject.Find("Speed (1)").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gear == Gear.P)
        {
            rigid.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            rigid.constraints = RigidbodyConstraints.FreezeRotation;
        }
        if (Input.GetKey("w"))
        {
            switch (gear)
            {
                case Gear.P:
                    break;
                case Gear.R:
                    rigid.AddForce(transform.rotation * Vector3.back * MoveSpeed * Time.deltaTime);
                    break;
                case Gear.N:
                    break;
                case Gear.D:
                    rigid.AddForce(transform.rotation * Vector3.forward * MoveSpeed * Time.deltaTime);
                    break;
            }
            
        }
        if (Input.GetKey("s"))
        {
            rigid.velocity *= BreakPower;
        }
        if (Input.GetKey("a"))
        {
            RotateAmount -= 2 * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            RotateAmount += 2 * Time.deltaTime;
        }
        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -RotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, RotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, -RotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(0, 0, RotateSpeed * Time.deltaTime);
        }*/
        transform.Rotate(0, RotateAmount, 0);
        RotateAmount *= 0.98f;
        td.text = Mathf.RoundToInt(Mathf.Abs(GetComponent<Rigidbody>().velocity.magnitude)).ToString();
        mstd.text = maxSpeed.ToString();
        if (GetComponent<Rigidbody>().velocity.magnitude > maxSpeed)
        {
            td.color = Color.red;
            aso.clip = speedover;
            if (!warn_playing)
            {
                aso.Play();
                warn_playing = true;
            }
        }
        else
        {
            td.color = Color.white;
            aso.Stop();
            warn_playing = false;
        }
    }
}
