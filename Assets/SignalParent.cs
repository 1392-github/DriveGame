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
            CurrentSignal += 1; // 다음 신호등을 초록불로 설정
            if (CurrentSignal >= DirectionCount) // 마지막 신호등이면
            {
                CurrentSignal = 0; // 처음 신호등을 초록불로 설정
            }
            SignalTimer = SignalTime[CurrentSignal];
        }
    }
}
