using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreManager : TienMonoBehaviour
{
    [SerializeField] protected long curScore;
    [SerializeField] protected long maxScore = 99999999999;
    [SerializeField] protected long highScore;
    [SerializeField] protected PlayerMovement playerMovement;
    public long CurScore => curScore;
    public event Action<long> OnScoreUpdate;
    public event Action OnHighScoreAppear;

    private void OnEnable()
    {
        playerMovement.OnPlayerFalling += UpdateScore;
    }

    private void Start()
    {
        curScore = 0;
        OnScoreUpdate?.Invoke(curScore);
        highScore = SaveSystems.LoadHighScore();
    }

    protected virtual void UpdateScore(long add)
    {
        if (curScore + add > maxScore) curScore = maxScore;
        else curScore += add;

        if (curScore >= maxScore) return;

        OnScoreUpdate?.Invoke(curScore);
    }

    public virtual void UpdateHighScoreWhenGameOver()
    {
        if (curScore > highScore)
        {
            highScore = curScore;
            SaveSystems.SaveHighScore(highScore);
            OnHighScoreAppear?.Invoke();
        }
    }

    private void OnDisable()
    {
        playerMovement.OnPlayerFalling -= UpdateScore;
    }
}
