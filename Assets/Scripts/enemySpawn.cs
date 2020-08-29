using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    //float startingYPos;
    //float nextSpawn = 0.0f;
    //Vector2 whereToSpawn;
    private float maxHeight = 4f;
    private float minHeight = -4f;

    public GameObject enemyPrefab;
    public float spawnRate = 1.0f;
    private Vector2 screenBounds;
    
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(enemyWave());
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(enemyPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x *-2, Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator enemyWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            spawnEnemy();
        }
    }
}
