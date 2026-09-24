using TMPro;
using UnityEngine;

public class ScoreOverTextCtrl : TienMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI scoreOverText;

    protected override void LoadComponents()
    {
        LoadScoreOverText();
    }

    protected virtual void LoadScoreOverText()
    {
        if (scoreOverText != null) return;
        scoreOverText = GetComponent<TextMeshProUGUI>();
    }

    public virtual void UpdateUI(long point)
    {
        scoreOverText.text = "You get \n" + point.ToString();
    }
}
