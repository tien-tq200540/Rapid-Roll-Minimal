using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointTextCtrl : TienMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI pointText;

    protected override void LoadComponents()
    {
        LoadPointText();
    }

    protected virtual void LoadPointText()
    {
        if (pointText != null) return;
        pointText = GetComponent<TextMeshProUGUI>();
    }

    public virtual void UpdateUI(long point)
    {
        pointText.text = point.ToString("D11");
    }
}
