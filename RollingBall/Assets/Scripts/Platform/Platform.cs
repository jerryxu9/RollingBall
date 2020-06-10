using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float boundY = 6f;

    void Start()
    {
        
    }

    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        this.transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        if (this.transform.position.y >= boundY)
            this.gameObject.SetActive(false);
    }
}
