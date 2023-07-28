using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasterEgg : MonoBehaviour
{
    public KeyCode[] keys = { KeyCode.T, KeyCode.E, KeyCode.S, KeyCode.T, KeyCode.Alpha1, KeyCode.Alpha3, KeyCode.Alpha9, KeyCode.Alpha2, KeyCode.Return };
    public int prog;
    public float timer;
    public GameObject easter;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (prog > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            timer = 1;
            prog = 0;
        }
        if (Input.GetKeyDown(keys[prog]))
        {
            prog += 1;
            if (prog >= keys.Length)
            {
                easter.SetActive(true);
            }
        }
    }
    public void warp()
    {
        SceneManager.LoadScene("TestMAP");
    }
}
