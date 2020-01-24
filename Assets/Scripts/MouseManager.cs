using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{

    public static MouseManager Instance;

    public bool visible;
    public CursorLockMode mode;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        Cursor.visible = visible;
        Cursor.lockState = mode;
    }

}
