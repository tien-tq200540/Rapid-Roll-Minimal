using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    [SerializeField] protected PlayerLifeCtrl playerLifeCtrl;

    protected override void LoadComponents()
    {
        LoadPlayerLifeCtrl();
    }

    protected virtual void LoadPlayerLifeCtrl()
    {
        if (playerLifeCtrl != null) return;
        playerLifeCtrl = GetComponent<PlayerLifeCtrl>();
        Debug.Log($"{transform.name}: LoadPlayerLifeCtrl");
    }

    public override void ReceiveDamage(int damage)
    {
        playerLifeCtrl.DeductHP( damage );
    }
}
