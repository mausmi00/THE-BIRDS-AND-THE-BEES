using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Random,
    Cat,
    Car,
    Hawk,
    Crate,
    Ground,
    Air
};

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private EnemyType mEnemyType;
    private EnemyType spawnedEnemyType;

    [SerializeField] private GameObject catPrefab;
    [SerializeField] private GameObject hawkPrefab;
    [SerializeField] private GameObject cratePrefab;
    [SerializeField] private GameObject carPrefab;

    public void Awake()
    {
        if (gameObject.GetComponent<Renderer>() != null)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
        Spawn();
    }

    public void Spawn()
    {
        GameObject chosenObject = GetPrefab(chooseEnemyType());
        GameObject spawnedObject = Instantiate(chosenObject, transform.position, Quaternion.identity);
    }

    private GameObject GetRandomPrefab()
    {
        int rand = Random.Range(1, 5);
        return GetPrefab((EnemyType)rand);
    }

    private EnemyType chooseEnemyType()
    {
        if (mEnemyType==EnemyType.Cat || mEnemyType == EnemyType.Crate || mEnemyType == EnemyType.Hawk || mEnemyType == EnemyType.Car)
        {
            return mEnemyType;
        }else if (mEnemyType==EnemyType.Ground){
            return (EnemyType)Random.Range(1, 3);
        }
        else if (mEnemyType == EnemyType.Air)
        {
            return (EnemyType)Random.Range(3, 5);
        }
        else
        {
            return (EnemyType)Random.Range(1, 5);
        }
    }
    
    private GameObject GetPrefab(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Cat:
                spawnedEnemyType = EnemyType.Cat;
                return catPrefab;
            case EnemyType.Hawk:
                spawnedEnemyType = EnemyType.Hawk;
                return hawkPrefab;
            case EnemyType.Crate:
                spawnedEnemyType = EnemyType.Crate;
                return cratePrefab;
            case EnemyType.Car:
                spawnedEnemyType = EnemyType.Car;
                return carPrefab;
            default:
                return GetRandomPrefab();
        }
    }
}
