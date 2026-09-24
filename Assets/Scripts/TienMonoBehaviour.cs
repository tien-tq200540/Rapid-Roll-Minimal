using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TienMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        LoadComponents();
    }

    protected virtual void Reset()
    {
        LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        //For override
    }
}
