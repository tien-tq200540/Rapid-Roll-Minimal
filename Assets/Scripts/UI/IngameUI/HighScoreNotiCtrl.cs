using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreNotiCtrl : TienMonoBehaviour
{
    protected Color redColor = Color.red;
    protected Color yellowColor = Color.yellow;
    [SerializeField] protected TextMeshProUGUI text;
    [SerializeField] protected float swapColorTime = 0.5f;
    protected string content = "High score!!!";
    protected Coroutine swapColorCoroutine;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHighScoreNotiText();
    }

    protected virtual void LoadHighScoreNotiText()
    {
        if (text != null) return;
        text = GetComponent<TextMeshProUGUI>();
        text.text = content;
    }

    private void OnEnable()
    {
        swapColorCoroutine = StartCoroutine(this.SwapColorCoroutine());
    }

    protected virtual IEnumerator SwapColorCoroutine()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(swapColorTime);
            HighScoreTxtSwapColor();
        }
    }

    protected virtual void HighScoreTxtSwapColor()
    {
        if (text.faceColor != redColor) text.faceColor = redColor;
        else text.faceColor = yellowColor;
    }

    private void OnDisable()
    {
        StopCoroutine(swapColorCoroutine);
    }
}
