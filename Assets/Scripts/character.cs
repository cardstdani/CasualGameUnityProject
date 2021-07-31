using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public float speed = 180f, upSpeedRate = .2f;

    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Application.targetFrameRate = 40;
        }

        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WebGLPlayer)
        {
            Application.targetFrameRate = 360;
        }

        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            Application.targetFrameRate = 60;
        }
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
        speed += upSpeedRate * Time.deltaTime;
    }

    public void change()
    {
        speed *= -1;
    }
}