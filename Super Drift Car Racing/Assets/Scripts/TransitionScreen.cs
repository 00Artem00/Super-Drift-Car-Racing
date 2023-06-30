using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScreen : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (CheckRace.flag == true)
        {
            anim.SetBool("endRace", true);
        }
    }
}
