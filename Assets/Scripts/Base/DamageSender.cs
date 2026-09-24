using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : TienMonoBehaviour
{
    [SerializeField] protected int damage;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out DamageReceiver damageReceiver)) {
            damageReceiver.ReceiveDamage(damage);
        }    
    }
}
