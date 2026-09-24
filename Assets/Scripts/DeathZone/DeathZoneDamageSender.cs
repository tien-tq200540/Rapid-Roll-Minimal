using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneDamageSender : DamageSender
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        SetDeathZoneDamage();
    }

    protected virtual void SetDeathZoneDamage()
    {
        this.damage = 999999;
    }
}
