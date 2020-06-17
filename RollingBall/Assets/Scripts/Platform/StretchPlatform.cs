using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchPlatform : Platform
{
    private float stretchSpeed = 0.2f;

    protected override void OnCollisionStay2D(Collision2D target)
    {
        base.OnCollisionStay2D(target);

        if (target.collider.tag == "Player")
        {
            if (this.transform.localScale.x < 1.0f)
            {
                Vector3 localScale = this.transform.localScale;
                localScale.x += stretchSpeed * Time.deltaTime;
                this.transform.localScale = localScale;
            }
        }
    }
}
