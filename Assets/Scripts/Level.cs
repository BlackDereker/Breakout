using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    public int BrickCount
    {
        get { return brickCount; }

        set
        {
            brickCount = value;

            if (brickCount == 0)
            {
                GameManager.Instance.GameWin();
            }
        }
    }

    private int brickCount;

   
}
