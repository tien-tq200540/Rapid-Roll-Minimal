using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeTextCtrl : TienMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI lifeText;
    protected string baseText = "  x ";

    protected override void LoadComponents()
    {
        LoadLifeText();
    }

    protected virtual void LoadLifeText()
    {
        if (lifeText != null) return;
        lifeText = GetComponent<TextMeshProUGUI>();
    }

    public virtual void UpdateUI(int curHP)
    {
        lifeText.text = baseText + curHP.ToString();
    }
}
