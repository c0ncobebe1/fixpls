using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : KinBehaviour
{
    
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> Prefabs;
    [SerializeField] protected List<Transform> poolObjs;

    

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if (this.Prefabs.Count > 0) return;

        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.Prefabs.Add(prefab);
        }

        this.HidePrefabs();
    }


    protected virtual void HidePrefabs()
    {
        //Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in Prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObj in this.poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newprefab = Instantiate(prefab);
        newprefab.name = prefab.name;
        return newprefab;
    }
    public virtual Transform Spawn(string prefabName ,Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning("Prefabs not found: "+ prefabName);
            return null;
        }

        Transform newprefab = this.GetObjectFromPool(prefab);
        newprefab.SetPositionAndRotation(spawnPos, rotation);

        newprefab.parent = this.holder;
        return newprefab;

    }


    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach(Transform prefab in Prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }

    public virtual void Despawn(Transform obj)
    {
        foreach (Transform poolobj in poolObjs)
        {
            if (poolobj == obj) { return; }
        }
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }
}
