using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrl : TienMonoBehaviour
{
    private static UICtrl instance;
    public static UICtrl Instance => instance;

    [SerializeField] protected LifeTextCtrl lifeTextCtrl;
    public LifeTextCtrl LifeTextCtrl => lifeTextCtrl;
    [SerializeField] protected PointTextCtrl pointTextCtrl;
    public PointTextCtrl PointTextCtrl => pointTextCtrl;


    protected override void Awake()
    {
        if (instance != null) Debug.LogError("Only 1 UICtrl allows to exist!");
        else instance = this;
        base.Awake();
    }

    protected override void LoadComponents()
    {
        LoadLifeTextCtrl();
        LoadPointTextCtrl();
    }

    protected virtual void LoadLifeTextCtrl()
    {
        if (lifeTextCtrl != null) return;
        lifeTextCtrl = GetComponentInChildren<LifeTextCtrl>();
    }

    protected virtual void LoadPointTextCtrl()
    {
        if (pointTextCtrl != null) return;
        pointTextCtrl = GetComponentInChildren<PointTextCtrl>();
    }
}
