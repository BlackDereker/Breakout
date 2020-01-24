using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    public static PoolManager Instance;

    // Ball Pool's variables
    public int ballPoolSize = 20;

    public Queue<Ball> ballPool;
    private Transform ballPoolTransform;

    // Ball model
    public GameObject ballPrefab;

    void Awake()
    {

        if(!ballPrefab)
        {
            Debug.LogError("Ball Prefab not set! Disabling Script");
            enabled = false;
        }

        Instance = this;

        ballPool = new Queue<Ball>(ballPoolSize);

        ballPoolTransform = new GameObject("Ball Pool").transform;
        ballPoolTransform.position = new Vector2(1000, 1000);

        // Populate the pool
        for(int i = 0; i < ballPoolSize; i++)
        {
            Ball clone = (Instantiate(ballPrefab, ballPoolTransform.position, Quaternion.identity, ballPoolTransform) as GameObject).GetComponent<Ball>();
            
            ballPool.Enqueue(clone);
        }

    }

    // Load ball to player launch it
    public Ball LoadBall()
    {

        Ball clone;

        if (ballPool.Count != 0)
        {
            clone = ballPool.Dequeue();
        }
        else
        {
            GameObject obj = Instantiate(ballPrefab, ballPoolTransform.position, Quaternion.identity, ballPoolTransform) as GameObject;
            clone = obj.GetComponent<Ball>();
        }

        return clone;
    }




    public void ResetBall(Ball ball)
    {

        ball.rigid.velocity = Vector2.zero;
        ball.rigid.simulated = false;
        ball.transform.position = ballPoolTransform.position;
        ball.transform.parent = ballPoolTransform;

        ballPool.Enqueue(ball);

        if (GameManager.Instance.currentState == GameManager.GameState.PLAYING)
        {

            if (ballPool.Count == ballPoolSize)
            {
                GameManager.Instance.player.Lives--;
                GameManager.Instance.player.cannon.LoadBall();
            }

        }

    }


}
