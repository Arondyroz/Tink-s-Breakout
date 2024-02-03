using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreNumberText;
    public GameObject StartPanel;

    public int scoreNumber = 0;

    private void Awake()
    {
        PlayerMovement.instance.startGame = false;
    }
    private void Update()
    {
        if (Input.anyKey)
        {
            StartPanel.SetActive(false);
            PlayerMovement.instance.startGame = true;
        }

        if (PlayerMovement.instance.isDead == false && PlayerMovement.instance.startGame == true && scoreNumber <= 5000)
        {
            scoreNumber++;
            scoreNumberText.text = scoreNumber.ToString();
        }
       
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
