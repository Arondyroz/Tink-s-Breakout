using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Texture2D cursorArrow;
    public GameObject losePanel;
    public AudioSource deadSFX;
    public UIManager uiMScript;
    public GameObject[] turretGo;
    public Animator canvasBG;
    Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void Update()
    {
        if (uiMScript.scoreNumber >= 5000)
        {
            PlayerMovement.instance.colPlayer.enabled = false;
            PlayerMovement.instance.transform.position = PlayerMovement.instance.currentPos;
            foreach (GameObject turret in turretGo)
            {
                turret.SetActive(false);
            }
            EndCredit();
        }
    }

    public void LosePanel()
    {
        StartCoroutine("LoseCoroutine");
    }

    public IEnumerator LoseCoroutine()
    {
        yield return new WaitForSeconds(2f);
        losePanel.SetActive(true);
    }

    void EndCredit()
    {
        PlayerMovement.instance.endGame = true;
        canvasBG.enabled = true;
    }
}
