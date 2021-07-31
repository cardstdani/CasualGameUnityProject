using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    public TMPro.TextMeshProUGUI highScoreText;
    GameObject character;
    float speed = 180;

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

        character = GameObject.Find("Character");
        highScoreText.text = PlayerPrefs.GetInt("maxScore").ToString();
    }

    public void play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("GameScene");
    }

    public void exit()
    {
        Application.Quit();
    }

    private void Update()
    {
        character.transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    public void change()
    {
        speed *= -1;
    }
}