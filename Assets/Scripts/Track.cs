using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public bool spawnOnAwake = false;
    public Transform birdhousePosition;
    private ObstacleSpawner[] mObstacleSpawners;
    private SeedSpawner[] mSeedSpawners;



    void Awake()
    {
        mObstacleSpawners = gameObject.GetComponentsInChildren<ObstacleSpawner>();
        mSeedSpawners = gameObject.GetComponentsInChildren<SeedSpawner>();
    }

    public void Start()
    {
        if (spawnOnAwake)
        {
            Spawn();
        }
    }
    public void Spawn()
    {
        for (int i = 0; i < mObstacleSpawners.Length; ++i)
        {
            mObstacleSpawners[i].Spawn();
        }
        for (int i = 0; i < mSeedSpawners.Length; ++i)
        {
            mSeedSpawners[i].Spawn();
        }
    }
}
