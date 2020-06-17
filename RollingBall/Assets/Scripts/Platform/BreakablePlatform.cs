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

    /// <summary>
    /// Call this function when animation finishes as an animation event
    /// </summary>
    private void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.3f);
    }

    private void DeactivateGameObject()
    {
        //SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }

    protected override void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            //SoundManager.instance.LandSound();
            anim.Play("Break");
        }
    }

}
