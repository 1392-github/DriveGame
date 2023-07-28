using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalParent : MonoBehaviour
{
    public int DirectionCount;
    public float[] SignalTime;
    public int CurrentSignal;
    public float SignalTimer;
    public float DisableCheckTimer;
    // Start is called before the first frame update
    void Start()
    {
        SignalTimer = SignalTime[CurrentSignal];
    }

    // Update is called once per frame
    void Update()
    {
        SignalTimer -= Time.deltaTime;
        DisableCheckTimer -= Time.deltaTime;
        if (SignalTimer <= 0)
        {
            CurrentSignal += 1; // ���� ��ȣ���� �ʷϺҷ� ����
            if (CurrentSignal >= DirectionCount) // ������ ��ȣ���̸�
            {
                CurrentSignal = 0; // ó�� ��ȣ���� �ʷϺҷ� ����
            }
            SignalTimer = SignalTime[CurrentSignal];
        }
    }
}
