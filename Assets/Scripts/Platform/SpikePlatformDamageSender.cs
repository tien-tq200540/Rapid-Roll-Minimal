using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePlatformDamageSender : DamageSender
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerDamageReceiver damageReceiver))
        {
            damageReceiver.ReceiveDamage(damage);
        }
    }
}
