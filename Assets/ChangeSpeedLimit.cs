using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    X,
    Z
}
public class ChangeSpeedLimit : MonoBehaviour
{
    public Direction direction;
    public float negMaxSpeed;
    public float posMaxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit(Collider other)
    {
        /*Transform parent = other.transform.parent;
        bool flag0 = false;
        while (parent != null)
        {
            // �θ� ������Ʈ�� "Car" ������Ʈ�� ��� true�� ��ȯ
            if (parent.gameObject.name == "Car")
                flag0 = true;

            // �θ� ������Ʈ�� �θ� �����ͼ� ��� Ž��
            parent = parent.parent;
        }
        if (!flag0)
        {
            return;
        }*/
        if (other.gameObject.name != "Car")
        {
            return;
        }
        switch (direction)
        {
            case Direction.X:
                if (transform.position.x < other.transform.position.x)
                {
                    other.GetComponent<CarController>().maxSpeed = posMaxSpeed;
                }
                else
                {
                    other.GetComponent<CarController>().maxSpeed = negMaxSpeed;
                }
                break;
            case Direction.Z:
                if (transform.position.z < other.transform.position.z)
                {
                    other.GetComponent<CarController>().maxSpeed = posMaxSpeed;
                }
                else
                {
                    other.GetComponent<CarController>().maxSpeed = negMaxSpeed;
                }
                break;
        }
    }
}
