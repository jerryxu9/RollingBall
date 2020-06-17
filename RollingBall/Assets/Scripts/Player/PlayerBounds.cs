using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private float min_X = -2.7f, max_X = 2.7f, min_Y = -5.6f;
    private bool out_of_bounds;

    private void Update()
    {
        Checkbounds();
    }

    private void Checkbounds()
    {
        Vector2 temp = this.transform.position;

        if (temp.x < min_X)
            temp.x = min_X;

        if (temp.x > max_X)
            temp.x = max_X;

        transform.position = temp;

        if (temp.y <= min_Y && !out_of_bounds)
        {
            out_of_bounds = true;
            //SoundManager.instance.DearhSound();
            //GameManager.instance.RestartGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Top Spike")
        {
            this.transform.position = new Vector2(1000f, 1000f);
            //SoundManager.instance.DeathSound();
            //GameManager.instance.RestartGame();
        }
    }
}
