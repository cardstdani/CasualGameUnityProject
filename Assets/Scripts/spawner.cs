using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject obj, rewardObj;
    public float timer = 0, rate = 2, upSpeed = 0.02f, force = 2;
    float speedRate = 0;
    string[] tags = { "Yellow", "Blue" };
    Color[] colors = { new Color(255, 247, 192, 255), new Color(0, 186, 192, 255) };

    private void Start()
    {
        colors[0] = GameObject.Find("Circle1").GetComponent<SpriteRenderer>().color;
        colors[1] = GameObject.Find("Circle2").GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > rate)
        {
            spawn();
            timer = 0;
        }

        speedRate += upSpeed * Time.deltaTime;
        rate -= 0.01f * Time.deltaTime;
    }

    void spawn()
    {
        int decision = Random.Range(0, 2);

        GameObject obj1 = null, obj2 = null;

        if (decision == 0)
        {
            obj1 = Instantiate(obj, new Vector3(0, 7, 91), transform.rotation);
            obj2 = Instantiate(obj, new Vector3(0, -7, 91), transform.rotation);

            obj1.GetComponentInChildren<obstacle>().direction = Vector3.up;
            obj2.GetComponentInChildren<obstacle>().direction = Vector3.up;
        }
        else
        {
            obj1 = Instantiate(obj, new Vector3(5, 0, 91), transform.rotation);
            obj2 = Instantiate(obj, new Vector3(-5, 0, 91), transform.rotation);

            obj1.GetComponentInChildren<obstacle>().direction = Vector3.right;
            obj2.GetComponentInChildren<obstacle>().direction = Vector3.right;
        }

        obj1.GetComponentInChildren<SpriteRenderer>().color = colors[1];
        obj1.tag = tags[1];
        obj2.GetComponentInChildren<SpriteRenderer>().color = colors[0];
        obj2.tag = tags[0];

        if (Random.Range(0, 2) == 1)
        {
            obj1.GetComponentInChildren<SpriteRenderer>().color = colors[0];
            obj1.tag = tags[0];
            obj2.GetComponentInChildren<SpriteRenderer>().color = colors[1];
            obj2.tag = tags[1];
        }

        obj1.GetComponentInChildren<obstacle>().speed += speedRate;
        obj2.GetComponentInChildren<obstacle>().speed += speedRate;

        if (Random.Range(0, 2) == 0)
        {
            if (Random.Range(0, 2) == 0)
            {
                Destroy(obj1);
            }
            else { Destroy(obj2); }
        }
    }
}