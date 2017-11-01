using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_anim : MonoBehaviour
{

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        float position_x = transform.position.x;
        float position_y = transform.position.y;

        bool isWalking = (Mathf.Abs(position_x) + Mathf.Abs(position_y)) > 0;

        anim.SetBool("isWalking", isWalking);
        if (isWalking)
        {
            anim.SetFloat("x", position_x);
            anim.SetFloat("y", position_y);

            //transform.position += new Vector3(position_x, position_y, 0).normalized * Time.deltaTime;
        }
    }
}
