using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnim : MonoBehaviour
{
    public static Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (ButtonEvents.flag == true)
        {
            anim.SetBool("LockCar", true);
        }
        else
        {
            anim.SetBool("LockCar", false);
        }
    }
}
