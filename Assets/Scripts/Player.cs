using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int Lives
    {

        get { return lives; }

        set
        {

            lives = value;

            if(lives == 0)
            {
                GameManager.Instance.GameOver();
            }
        }

    }

    public int startLives;

    public Cannon cannon;

    [HideInInspector]
    public PlayerMovement playerMovement;

    [SerializeField]
    private int lives = 3;
    

    void Awake()
    {
        startLives = Lives;
        playerMovement = GetComponent<PlayerMovement>();

    }

    void Update()
    {

        if (cannon && Input.GetMouseButtonUp(0))
        {
            cannon.LaunchBall();
        }

    }

    public void ResetPlayer()
    {
        Lives = startLives;
        StartCoroutine(cannon.DelayedLoadBall(1f));
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        // Check if collided with a ball
        if(col.gameObject.tag == "Ball")
        {

            // Get ball
            Ball ball = col.gameObject.GetComponent<Ball>();

            // Calculate the direction the ball should go
            Vector2 dir = ball.transform.position - transform.position;

            // Calculate velocity
            dir = new Vector2(dir.x / 2, dir.y).normalized * ball.rigid.velocity.magnitude;

            ball.rigid.velocity = dir;

        }

    }

}
