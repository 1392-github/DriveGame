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
        if (parent.CurrentSignal == Direction) // 현재 이 신호등이 초록불인 상태라면
        {
            if (parent.SignalTimer <= 5) // 5초 이내에 빨간불로 바뀐다면
            {
                transform.Find("Cube.001").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", YellowLight); // 노란불 켜기
            }
            else
            {
                transform.Find("Cube.001").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", GreenLight); // 초록불 켜기
            }
        }
        else
        {
            transform.Find("Cube.001").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", RedLight); // 빨간불 켜기
        }
    }
}
