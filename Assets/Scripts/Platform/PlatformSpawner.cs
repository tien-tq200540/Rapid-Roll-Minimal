using UnityEngine;

public class PlatformSpawner : Spawner
{
    private static PlatformSpawner instance;
    public static PlatformSpawner Instance => instance;

    protected override void Awake()
    {
        if (instance != null) Debug.LogError($"Only 1 instance of {transform.name} allows to exist!");
        else instance = this;
        base.Awake();
    }

    public virtual Transform SpawnNormalPlatform(Vector2 position)
    {
        return Spawn("NormalPlatform", position);
    }

    public virtual Transform SpawnSpikePlatform(Vector2 position)
    {
        return Spawn("SpikePlatform", position);
    }

    public virtual Transform SpawnTrampolinePlatform(Vector2 position)
    {
        return Spawn("TrampolinePlatform", position);
    }
}
