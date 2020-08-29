using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdhouse : MonoBehaviour
{
    public GameObject particleObject;
    private BirdyMover mBirdyMover;
    [SerializeField] private SpriteRenderer mainSpriteRenderer;
    [SerializeField] private SpriteRenderer foregroundSpriteRenderer;
    public AudioSource audioSource; 

    private Color mTintColor = Color.white;



    // Start is called before the first frame update
    void Awake()
    {
        mBirdyMover = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdyMover>();
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartFunTimes()
    {
        StartCoroutine(FunTimes());
    }

    private IEnumerator FunTimes()
    {
        //brief wait
        yield return new WaitForSeconds(0.5f);
        //fun times
        particleObject.SetActive(true);
        particleObject.GetComponent<ParticleSystem>().Play();
        audioSource.Play();
        yield return new WaitForSeconds(2f);
        //stop fun times
        particleObject.GetComponent<ParticleSystem>().Stop();
        //display baby bird
        yield return new WaitForSeconds(5f);
        particleObject.SetActive(false);
        //take off
        mBirdyMover.SetBirdyState(BirdyState.Takeoff);

    }

    public void Place(Vector3 position)
    {
        transform.position = position;
        mTintColor = Random.ColorHSV(0f, 1f, 0f, 0.2f, 0.9f, 1f);
        mainSpriteRenderer.color = mTintColor;
        foregroundSpriteRenderer.color = mTintColor;

    }
}
