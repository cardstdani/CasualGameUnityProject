using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{
    public AudioSource sound;
    public Animator anim, textAnim;
    public GameObject highScoreImage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.tag == gameObject.tag)
        {
            anim.SetTrigger("New Trigger");
            textAnim.SetTrigger("New Trigger");
            Destroy(collision.gameObject);

            int currentScore = int.Parse(GameObject.Find("Text").GetComponent<TMPro.TextMeshProUGUI>().text) + 1;
            GameObject.Find("Text").GetComponent<TMPro.TextMeshProUGUI>().text = currentScore.ToString();

            if (currentScore > PlayerPrefs.GetInt("maxScore"))
            {
                PlayerPrefs.SetInt("maxScore", currentScore);
                highScoreImage.SetActive(true);
            }

            sound.Play();
        }
        else
        { UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MainMenu"); }
    }
}