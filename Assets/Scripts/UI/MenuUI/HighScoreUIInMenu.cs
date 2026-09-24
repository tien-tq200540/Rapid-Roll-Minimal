using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreUIInMenu : TienMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI text;

    protected override void LoadComponents()
    {
        LoadText();
    }

    private void OnEnable()
    {
        LoadHighScoreText();
    }

    protected virtual void LoadHighScoreText()
    {
        text.text = "HIGHSCORE:\n" + SaveSystems.LoadHighScore().ToString();
    }

    protected virtual void LoadText()
    {
        if (text != null) return;
        text = transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
    }
}
