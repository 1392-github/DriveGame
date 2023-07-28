using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalChild : MonoBehaviour
{
    public int Direction;
    public SignalParent parent;
    public Texture RedLight;
    public Texture YellowLight;
    public Texture GreenLight;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.GetComponent<SignalParent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.CurrentSignal == Direction) // ���� �� ��ȣ���� �ʷϺ��� ���¶��
        {
            if (parent.SignalTimer <= 5) // 5�� �̳��� �����ҷ� �ٲ�ٸ�
            {
                transform.Find("Cube.001").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", YellowLight); // ����� �ѱ�
            }
            else
            {
                transform.Find("Cube.001").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", GreenLight); // �ʷϺ� �ѱ�
            }
        }
        else
        {
            transform.Find("Cube.001").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", RedLight); // ������ �ѱ�
        }
    }
}
