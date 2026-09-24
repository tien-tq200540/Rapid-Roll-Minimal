using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : TienMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs = new();
    [SerializeField] protected List<Transform> poolObjs = new();
    [SerializeField] protected Transform holder;

    protected override void LoadComponents()
    {
        LoadHolder();
    }

    protected virtual void LoadHolder()
    {
        if (holder != null) return;
        holder = transform.Find("Holder");
        Debug.Log($"{transform.name}: LoadHolder");
    }

    protected virtual Transform Spawn(string prefabName, Vector2 position)
    {
        Transform prefab = GetPrefabByName(prefabName);
        if (prefab == null) return prefab;
        return this.Spawn(prefab, position);
    }

    protected virtual Transform Spawn(Transform prefab, Vector2 position)
    {
        Transform spawnObj = GetObjFromPool(prefab);
        if (spawnObj == null)
        {
            spawnObj = Instantiate(prefab);
            spawnObj.name = prefab.name;
            spawnObj.SetParent(holder);
        }
        spawnObj.SetPositionAndRotation(position, Quaternion.identity);
        spawnObj.gameObject.SetActive(true);
        return spawnObj;
    }

    protected virtual Transform GetObjFromPool(Transform prefab)
    {
        foreach(Transform t in poolObjs)
        {
            if (t.name == prefab.name)
            {
                poolObjs.Remove(t);
                return t;
            }
        }
        return null;
    }

    protected virtual Transform GetPrefabByName(string prefabName)
    {
        foreach(Transform t in prefabs)
        {
            if (t.name == prefabName) return t;
        }
        return null;
    }

    public virtual void Despawn(Transform obj)
    {
        poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }
}
