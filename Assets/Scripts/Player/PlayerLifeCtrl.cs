using System;
using UnityEngine;

public class PlayerLifeCtrl : TienMonoBehaviour
{
    [SerializeField] protected int curHP = 1;
    [SerializeField] protected int maxHP = 5;
    public bool IsDeath => curHP <= 0;
    
    public event Action OnDeath;
    public event Action<int> OnPlayerHPUpdate;

    private void Start()
    {
        curHP = 1;
        OnPlayerHPUpdate?.Invoke(curHP);
    }

    public virtual void DeductHP(int deduct)
    {
        if (IsDeath) return;
        curHP -= deduct;

        if (curHP < 0) curHP = 0;
        OnPlayerHPUpdate?.Invoke(curHP);

        if (IsDeath)
        {
            OnDeath?.Invoke();
            transform.parent.gameObject.SetActive(false);
        }
    }

    public virtual void AddHP(int add)
    {
        if (IsDeath) return;
        curHP += add;

        if (curHP > maxHP) curHP = maxHP;
        OnPlayerHPUpdate?.Invoke(curHP);
    }
}
