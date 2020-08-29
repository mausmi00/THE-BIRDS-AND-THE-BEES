using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //Debug.Log("clicked");
        StartCoroutine(WaitForSceneLoad());
       // SceneManager.LoadScene("Capsule + HealthBar", LoadSceneMode.Single);

    }

    public IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
