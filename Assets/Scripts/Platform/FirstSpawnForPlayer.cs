using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSpawnForPlayer : TienMonoBehaviour
{
    [SerializeField] protected List<Transform> initSpawnPos;

    protected override void LoadComponents()
    {
        LoadInitSpawnPos();
    }

    protected virtual void LoadInitSpawnPos()
    {
        foreach (Transform t in transform)
        {
            initSpawnPos.Add(t);
        }
    }

    public virtual void FirstInit()
    {
        foreach (Transform t in  initSpawnPos)
        {
            PlatformSpawner.Instance.SpawnNormalPlatform(t.position);
        }
    }
}
