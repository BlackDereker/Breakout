using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{

    // Ball's initial speed
    public float initialSpeed = 10f;

    [HideInInspector]
    public Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        // Get ball's rigidbody
        rigid = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if(col.tag == "Reset Trigger")
        {
            PoolManager.Instance.ResetBall(this);
        }

    }

}
