using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalStopLine : MonoBehaviour
{
    public int dir;
    public CarController car;
    public SignalParent signal;
    public Direction direction;
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("Car").GetComponent<CarController>();
        signal = transform.parent.GetComponent<SignalParent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name != "Car")
        {
            return;
        }
        if (signal.DisableCheckTimer > 0)
        {
            return;
        }
        signal.DisableCheckTimer = 20;
        if (signal.CurrentSignal != dir) // 이 신호등이 빨간불 상태면
        {
            Vector3 diff = car.GetComponent<Rigidbody>().velocity;
            diff.x = Mathf.Abs(diff.x);
            diff.z = Mathf.Abs(diff.z);
            switch (direction)
            {
                case Direction.X:
                    if (diff.x >= diff.z)
                    {
                        // 신호위반 20점 감점
                        car.score -= 20;
                    }
                    break;
                case Direction.Z:
                    if (diff.z >= diff.x)
                    {
                        // 신호위반 20점 감점
                        car.score -= 20;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
