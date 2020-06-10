using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : Platform
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    
}
