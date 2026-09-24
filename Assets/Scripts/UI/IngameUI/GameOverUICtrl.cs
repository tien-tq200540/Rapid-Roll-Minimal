using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUICtrl : TienMonoBehaviour
{
    [SerializeField] protected Button restartButton;
    [SerializeField] protected Button backToMenuButton;
    [SerializeField] protected ScoreOverTextCtrl scoreOverTxt;
    [SerializeField] protected HighScoreNotiCtrl highScoreNotiCtrl;

    public Button RestartButton => restartButton;
    public Button BackToMenuButton => backToMenuButton;
    public ScoreOverTextCtrl ScoreOverTxt => scoreOverTxt;
    public HighScoreNotiCtrl HighScoreNotiCtrl => highScoreNotiCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadRestartButton();
        LoadBackToMenuButton();
        LoadScoreOverTxt();
        LoadHighScoreNotiCtrl();
    }

    protected virtual void LoadHighScoreNotiCtrl()
    {
        if (highScoreNotiCtrl != null) return;
        highScoreNotiCtrl = transform.Find("HighScoreNotiTxt").GetComponent<HighScoreNotiCtrl>();
    }

    protected virtual void LoadScoreOverTxt()
    {
        if (scoreOverTxt != null) return;
        scoreOverTxt = transform.Find("ScoreOverTxt").GetComponent<ScoreOverTextCtrl>();
    }

    protected virtual void LoadBackToMenuButton()
    {
        if (backToMenuButton != null) return;
        backToMenuButton = transform.Find("BackToMenuButton").GetComponent<Button>();
    }

    protected virtual void LoadRestartButton()
    {
        if (restartButton != null) return;
        restartButton = transform.Find("RestartButton").GetComponent<Button>();
    }
}
