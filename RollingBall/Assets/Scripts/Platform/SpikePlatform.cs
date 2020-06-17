using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePlatform : Platform
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            target.transform.position = new Vector2(1000f, 1000f);
            //SoundManager.instance.GameOverSound();
            //GameManager.instance.RestartGame();
        }
    }
}
