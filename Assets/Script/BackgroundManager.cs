using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private RawImage backgroundImg;
    [SerializeField] private float xAxis;
    private RectTransform myRect;
    // Update is called once per frame

    private void Start()
    {
        myRect = GetComponent<RectTransform>();
    }
    void Update()
    {
        Vector2 rectPosX = myRect.localPosition;
        rectPosX.x--;
        MoveBackground();
    }

    private void MoveBackground()
    {
        backgroundImg.uvRect = new Rect(backgroundImg.uvRect.position + new Vector2(xAxis, 0) * Time.deltaTime, backgroundImg.uvRect.size);
    }
}
