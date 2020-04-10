using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrekBehaviour : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("move", 0);
        
    }
}
