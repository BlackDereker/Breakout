using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    [System.Serializable]
    public struct Constraints
    {
       public bool x, y;
    }

    public Constraints constraints;

    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get mouse world position
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float x = constraints.x ? transform.position.x : mousePos.x,
              y = constraints.y ? transform.position.y : mousePos.y;

        // Calculte target position
        Vector2 newPos = new Vector2(x, y);

        // Move the player to the target
        rigid.MovePosition(newPos);
    }
}
