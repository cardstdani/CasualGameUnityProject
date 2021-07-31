using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public float rotateSpeed = 60f, speed = .2f;
    public Vector3 direction;

    private void Start()
    {
        if (Random.Range(0, 2) == 1)
        {
            rotateSpeed *= -1;
        }

        if (transform.parent.localPosition.x == 0)
        {
            if (transform.parent.localPosition.y > 0)
            {
                speed *= -1;
            }
        }
        else
        {
            if (transform.parent.localPosition.x > 0)
            {
                speed *= -1;
            }
        }
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
        transform.parent.Translate(direction * speed * Time.deltaTime);
    }
}