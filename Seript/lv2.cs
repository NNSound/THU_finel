using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv2 : MonoBehaviour
{
    //三個我都不用了 省得刪掉又新增
    public GameObject lv3;
    void Start()
    {

    }
    void Update()
    {
        if (choose_level.lv_counter == 3)
        {
            Destroy(gameObject);
            Vector3 lv_pos = new Vector3(0, 1, 0);
            Instantiate(lv3, lv_pos, transform.rotation);
        }
    }
}
