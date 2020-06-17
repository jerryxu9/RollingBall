using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPlatform : Platform
{
    public bool isLeft;

    protected override void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (isLeft)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1.5f);
            }
            else
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1.5f);
            }
        }
    }

}
