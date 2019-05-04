using UnityEngine;

[RequireComponent(typeof(PoolComponent))]
public class SpawnComponent : MonoBehaviour
{
    public float SpawnRate;
    public bool ManualTrigger;

    private float _spawnTimer;
    private PoolComponent _poolComponent;

    private void Awake()
    {
        _poolComponent = GetComponent<PoolComponent>();
        ResetTimer();
    }

    private void Update()
    {
        if (ManualTrigger)
        {
            return;
        }

        if (Time.time > _spawnTimer)
        {
            SpawnObject();
        }
    }

    private GameObject GetItemFromPool()
    {
        _spawnTimer = Time.time + SpawnRate;
        return _poolComponent.GetItem();
    }

    private void SpawnObject()
    {
        GameObject item = GetItemFromPool();
        if (item != null)
        {
            //item.GetComponent<IGameObject>().Initialize();
        }
    }

    //public void SpawnObject(BaseSpawnMessage message)
    //{
    //    GameObject item = GetItemFromPool();
    //    if (item != null)
    //    {
    //        item.GetComponent<IGameObject>().Initialize(message);
    //    }
    //}

    public void ResetTimer()
    {
        _spawnTimer = Time.time + SpawnRate;
    }

    public bool IsActiveObjectInPool()
    {
        return _poolComponent.IsActive();
    }
}