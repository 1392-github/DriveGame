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
        if (signal.CurrentSignal != dir) // �� ��ȣ���� ������ ���¸�
        {
            Vector3 diff = car.GetComponent<Rigidbody>().velocity;
            diff.x = Mathf.Abs(diff.x);
            diff.z = Mathf.Abs(diff.z);
            switch (direction)
            {
                case Direction.X:
                    if (diff.x >= diff.z)
                    {
                        // ��ȣ���� 20�� ����
                        car.score -= 20;
                    }
                    break;
                case Direction.Z:
                    if (diff.z >= diff.x)
                    {
                        // ��ȣ���� 20�� ����
                        car.score -= 20;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
