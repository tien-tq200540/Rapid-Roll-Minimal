using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : TienMonoBehaviour
{
    [SerializeField] protected PlayerLifeCtrl playerLifeCtrl;
    [SerializeField] protected PlayerScoreManager playerScoreManager;
    [SerializeField] protected GameOverUICtrl gameOverUICtrl;

    private void OnEnable()
    {
        playerLifeCtrl.OnPlayerHPUpdate += UpdatePlayerHP;
        playerScoreManager.OnScoreUpdate += UpdatePlayerPoint;
        playerScoreManager.OnHighScoreAppear += OnHighScoreAppearHandle;
        gameOverUICtrl.RestartButton.onClick.AddListener(RestartGame);
        gameOverUICtrl.BackToMenuButton.onClick.AddListener(BackToMenu);
        playerLifeCtrl.OnDeath += GameOver;
    }

    protected virtual void OnHighScoreAppearHandle()
    {
        gameOverUICtrl.HighScoreNotiCtrl.gameObject.SetActive(true);
    }

    protected virtual void UpdatePlayerPoint(long point)
    {
        UICtrl.Instance.PointTextCtrl.UpdateUI(point);
    }

    protected virtual void UpdatePlayerHP(int curHP)
    {
        UICtrl.Instance.LifeTextCtrl.UpdateUI(curHP);
    }

    protected virtual void GameOver()
    {
        Time.timeScale = 0f;
        gameOverUICtrl.gameObject.SetActive(true);
        gameOverUICtrl.ScoreOverTxt.UpdateUI(playerScoreManager.CurScore);
        playerScoreManager.UpdateHighScoreWhenGameOver();
    }

    protected virtual void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    protected virtual void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
        Time.timeScale = 1f;
    }

    private void OnDisable()
    {
        gameOverUICtrl.RestartButton.onClick.RemoveListener(RestartGame);
        gameOverUICtrl.BackToMenuButton.onClick.RemoveListener(BackToMenu);
        playerLifeCtrl.OnPlayerHPUpdate -= UpdatePlayerHP;
        playerScoreManager.OnScoreUpdate -= UpdatePlayerPoint;
        playerLifeCtrl.OnDeath -= GameOver;
    }
}
