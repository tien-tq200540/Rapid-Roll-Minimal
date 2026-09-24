using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnRule : TienMonoBehaviour
{
    [SerializeField] protected Vector2 minLeftSpawnPos = new(-1.95f, -6f);
    [SerializeField] protected Vector2 maxRightSpawnPos = new(1.95f, -6f);
    [SerializeField] protected float timeToSpawn = 0.75f;
    [SerializeField] protected Vector2 spawnPos;
    [SerializeField] protected FirstSpawnForPlayer firstSpawnForPlayer; 

    [Header("Normal Platform SpawnRule")]
    [SerializeField] protected int minNormalPlatform = 3;
    [SerializeField] protected int maxNormalPlatform = 6;
    [SerializeField] protected int curNormalPlatformCanSpawn;
    [SerializeField] protected int curNormalPlatformSpawned = 0;

    [Header("Spike Platform SpawnRule")]
    [SerializeField] protected int minSpikePlatform = 1;
    [SerializeField] protected int maxSpikePlatform = 3;
    [SerializeField] protected int curSpikePlatformCanSpawn;
    [SerializeField] protected int curSpikelPlatformSpawned = 0;

    private void Start()
    {
        firstSpawnForPlayer.FirstInit();
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(this.Spawn), timeToSpawn, timeToSpawn);
    }

    protected virtual void Spawn()
    {
        spawnPos.x = Random.Range(minLeftSpawnPos.x, maxRightSpawnPos.x);
        spawnPos.y = minLeftSpawnPos.y;

        if (curNormalPlatformSpawned == curNormalPlatformCanSpawn)
        {
            if (curSpikelPlatformSpawned == curSpikePlatformCanSpawn)
            {
                PlatformSpawner.Instance.SpawnTrampolinePlatform(spawnPos);
                curSpikelPlatformSpawned = 0;
                curSpikePlatformCanSpawn = Random.Range(minSpikePlatform, maxSpikePlatform + 1);
            } else
            {
                PlatformSpawner.Instance.SpawnSpikePlatform(spawnPos);
                curSpikelPlatformSpawned++;
            }

            curNormalPlatformSpawned = 0;
            curNormalPlatformCanSpawn = Random.Range(minNormalPlatform, maxNormalPlatform + 1);
            return;
        }
        
        PlatformSpawner.Instance.SpawnNormalPlatform(spawnPos);
        curNormalPlatformSpawned++;
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
