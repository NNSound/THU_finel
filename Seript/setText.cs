using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setText : MonoBehaviour {
    public float Speed = 100;
    public float waiingtime = 2;

    Vector3 WaveTextPos = new Vector3 (0,0,0);
    Vector3 WaveTextPosStart = new Vector3 (-330,0,0);
    Vector3 WaveTextPosEnd = new Vector3 (330,0,0);
    public RectTransform rt;
    

    void Update()
    {
        rt = GetComponent<RectTransform>();
        rt.anchoredPosition3D = Vector3.MoveTowards(rt.anchoredPosition3D,WaveTextPos,Time.deltaTime * Speed);
        if (rt.anchoredPosition3D == WaveTextPos)
            StartCoroutine(Wait(waiingtime));
    }
    IEnumerator Wait(float time)
    {
        yield  return new WaitForSeconds(time);
        WaveTextPos = WaveTextPosEnd;
    }
    public void recover(){
        rt.anchoredPosition3D = WaveTextPosStart;
        WaveTextPos = new Vector3 (0,0,0);
    }

}
