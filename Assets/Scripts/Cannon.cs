using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    private Ball loadedBall;
    
    public IEnumerator DelayedLoadBall(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        LoadBall();
    }

    public void LoadBall()
    {
        loadedBall = PoolManager.Instance.LoadBall();

        // Detach ball from pool
        loadedBall.transform.parent = transform;

        // Update ball's Position and Rotation
        loadedBall.transform.position = transform.position;
        loadedBall.transform.rotation = transform.rotation;

    }

    // Launch ball and returns launched ball
    public void LaunchBall()
    {

        if (loadedBall)
        {

            // Detach ball from cannon
            loadedBall.transform.parent = null;

            // Turn on ball's physics simulation
            loadedBall.rigid.simulated = true;

            // Set initial ball's velocity
            loadedBall.rigid.velocity = new Vector2(0, loadedBall.initialSpeed);

            loadedBall = null;

        }


    }

}
