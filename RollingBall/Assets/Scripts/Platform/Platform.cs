using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float moveSpeed;
    public float boundY;

    private void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        this.transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        if (this.transform.position.y >= boundY)
            this.gameObject.SetActive(false);
    }

    protected virtual void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            SoundManager.instance.LandSound();
        }
    }

    protected virtual void OnCollisionStay2D(Collision2D collision){}

}
