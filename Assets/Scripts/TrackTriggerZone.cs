using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTriggerZone : MonoBehaviour
{

    private TrackManager mTrackManager;
    private Vector2 screenBounds;

    //Enemy spawn 
    private float maxHeight = 4f;
    private float minHeight = -4f;
    //public GameObject enemyPrefab, seedPrefab;
    //public float spawnRate = 1.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        mTrackManager = transform.parent.parent.gameObject.GetComponent<TrackManager>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            Debug.Log("trigger zone entered");
            mTrackManager.SetNextTrack();
            //spawnEnemy();
            //spawnSeed();
        }
        
    }

    //private void spawnEnemy()
    //{
    //    GameObject a = Instantiate(enemyPrefab) as GameObject;
    //    a.transform.position = new Vector2(gameObject.transform.position.x * 2, Random.Range(-4f,4f));
    //    GameObject b = Instantiate(enemyPrefab) as GameObject;
    //    b.transform.position = new Vector2(gameObject.transform.position.x * 3, Random.Range(-4f, 4f));
    //    GameObject c = Instantiate(enemyPrefab) as GameObject;
    //    c.transform.position = new Vector2(gameObject.transform.position.x + 1 * 3, Random.Range(-4f, 4f));
    //    if(a.transform.position.x< screenBounds.x || b.transform.position.x < screenBounds.x || c.transform.position.x < screenBounds.x)
    //    {
    //        Destroy(a);
    //    }
    //}

    //private void spawnSeed()
    //{
    //    GameObject seed = Instantiate(seedPrefab) as GameObject;
    //    seed.transform.position = new Vector2(gameObject.transform.position.x * 2, Random.Range(-4f, 4f));
    //}
}
