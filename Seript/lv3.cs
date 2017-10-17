    //三個我都不用了 省得刪掉又新增
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv3 : MonoBehaviour
{
    //三個我都不用了 省得刪掉又新增
    public GameObject lv1;
    void Start()
    {

    }
    void Update()
    {
        if (choose_level.lv_counter == 1)
        {
            Destroy(gameObject);
            Vector3 lv_pos = new Vector3(0, 1, 0);
            Instantiate(lv1, lv_pos, transform.rotation);
        }
    }
}
