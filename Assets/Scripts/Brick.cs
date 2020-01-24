using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Brick : MonoBehaviour
{

    private static readonly Color[] lifeColors =
    {
        Color.red,
        Color.green,
        Color.blue,
        Color.yellow,
        Color.magenta,
        Color.cyan
    };

    public GameObject brokenPrefab;

    public int Lives
    {
        get { return _lives; }

        set
        {
            _lives = value;
            UpdateColor();
        }
    }

    [SerializeField]
    private int _lives = 1;

    private SpriteRenderer render;

    // Start is called before the first frame update
    void Start()
    {

        render = GetComponent<SpriteRenderer>();

        Lives = _lives;

        LevelManager.Instance.CurrentLevel.BrickCount++;

    }

    void UpdateColor()
    {

        if (Lives <= 0)
        {
            DestroyBrick();
        }
        else
        {
            int colorIndex = (Lives - 1) % lifeColors.Length;
            render.color = lifeColors[colorIndex];
        }

    }

    void DestroyBrick()
    {
        LevelManager.Instance.CurrentLevel.BrickCount--;
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {

            if (brokenPrefab)
            {

                GameObject clone = Instantiate(brokenPrefab, transform.position, transform.rotation);

                SpriteRenderer cloneRenderer = clone.GetComponent<SpriteRenderer>();

                if (cloneRenderer)
                {
                    cloneRenderer.color = render.color;
                    
                } 

                Rigidbody2D cloneRigidbody = clone.GetComponent<Rigidbody2D>();

                if (cloneRigidbody)
                {
 
                    float cloneSpeed = 5f;

                    Vector2 cloneVelocity = (transform.position - col.transform.position).normalized * cloneSpeed;

                    cloneRigidbody.velocity = cloneVelocity;
                    cloneRigidbody.angularVelocity = -cloneVelocity.x * 50;

                }

            }

            Lives--;

        }
    }

}
