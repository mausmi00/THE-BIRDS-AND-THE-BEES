using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    private Coroutine loadSceneCoroutine = null;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    public bool CueWaitAndLoad(string sceneName, float timeToWait)
    {
        if (loadSceneCoroutine == null)
        {
            loadSceneCoroutine = StartCoroutine(WaitAndLoad(sceneName, timeToWait));
            return true;
        }
        return false;
    }

    

    private IEnumerator WaitAndLoad(string sceneName, float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(sceneName);
        loadSceneCoroutine = null;
    }
}
