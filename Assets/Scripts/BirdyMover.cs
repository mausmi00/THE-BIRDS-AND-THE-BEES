using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public enum BirdyState
{
    Default,
    Flying,
    Landing,
    Nesting,
    Takeoff,
    Dead
};

public class BirdyMover : MonoBehaviour
{
    //------------------------------
    private float mHSpeed;
    private float mVSpeed;
    private BirdyState mBirdyState = BirdyState.Default;
    private Rigidbody mRigidbody;
    [SerializeField] private Animator mBirdyAnimator;
    [SerializeField] private SpriteRenderer mBirdySpriteRenderer;
    //[SerializeField] private Material featherMaterial;
    [SerializeField] private ParticleSystem featherSystem;
    [SerializeField] private GameObject particleHolder;
    private BackgroundManager mBackgroundManager;
    private Birdhouse mBirdhouse;
    private Color tintColor = Color.white;

    public AudioSource as1, as2;
    public AudioSource[] audio;
    private float maxHeight = 4f;
    private float minHeight = -4f;

    private Transform mTargetTransform;


    public float HSpeed
    {
        get { return mHSpeed; }
    }
    public float VSpeed
    {
        get { return mVSpeed; }
    }




    //------------------------------Unity Functions------------------------------
    void Awake()
    {
        RandomizeBirdy();
        mBackgroundManager = GameObject.Find("BackgroundManager").GetComponent<BackgroundManager>();
        mBirdhouse = GameObject.FindGameObjectWithTag("Birdhouse").GetComponent<Birdhouse>();
        SetBirdyState(BirdyState.Flying);
        //audio = GetComponents<AudioSource>();
        as1 = audio[0];
        as2 = audio[1];
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(mBirdyState);
        //Move Birdy
        float yMovement = Input.GetAxis("Vertical");
        Vector3 tempPosition = transform.position;
        switch (mBirdyState)
        {
            case BirdyState.Default:
                break;
            case BirdyState.Flying:
                tempPosition.x += HSpeed * Time.deltaTime;

                tempPosition.y += yMovement * VSpeed * Time.deltaTime;
                tempPosition.y = Mathf.Clamp(tempPosition.y, minHeight, maxHeight);

                transform.position = tempPosition;
                //Debug.Log(yMovement);
                UpdateAnimation(yMovement);
                break;
            case BirdyState.Landing:
                yMovement = Mathf.Clamp(mTargetTransform.position.y - transform.position.y, -1f, 1f);
                tempPosition.x += HSpeed * Time.deltaTime;

                tempPosition.y += yMovement * VSpeed * Time.deltaTime;
                tempPosition.y = Mathf.Clamp(tempPosition.y, minHeight, maxHeight);

                transform.position = tempPosition;
                //Debug.Log(yMovement);
                UpdateAnimation(yMovement);
                break;
            case BirdyState.Nesting:
                break;
            case BirdyState.Takeoff:
                break;
            case BirdyState.Dead:
                break;
            default:
                break;
        }

    }
    private void RandomizeBirdy()
    {
        mVSpeed = Random.Range(3f, 4f);
        mHSpeed = Random.Range(4f, 5f);
        tintColor = Random.ColorHSV(0f, 1f, 0.1f, 0.3f, 0.7f, 1f);
        featherSystem.startColor = tintColor;
        mBirdySpriteRenderer.color = tintColor;

    }

    private void UpdateAnimation(float yMovement)
    {
        mBirdyAnimator.SetFloat("VerticalVelocity", yMovement);
    }


    public void SetTarget(Transform target)
    {
        mTargetTransform = target;
    }

    public bool TryToKill()
    {
        if (mBirdyState == BirdyState.Flying)
        {
            SetBirdyState(BirdyState.Dead);

            return true;
        }
        return false;
    }

    public void SetBirdyState(BirdyState newBirdyState)
    {
        if (mBirdyState == newBirdyState) { return;  }
        Debug.Log("Birdy: " + mBirdyState + " -> " + newBirdyState);
        switch (newBirdyState)
        {
            case BirdyState.Default:

                break;
            case BirdyState.Flying:
                mBackgroundManager.Unfreeze();
                //enable collisions
                //free control
                break;
            case BirdyState.Landing:
                //disable collisions
                //move towards Birdhouse target
                break;
            case BirdyState.Nesting:
                //birdy is in nest. Do nothing there. 
                mBackgroundManager.Freeze();
                mBirdhouse.StartFunTimes();
                break;
            case BirdyState.Takeoff:
                StartCoroutine(Takeoff());
                //birdy is taking off. Trigger takeoff sequence
                break;
            case BirdyState.Dead:
                //no movement
                mBackgroundManager.Freeze();
                //hide birdy
                mBirdySpriteRenderer.enabled = false;
                //trigger death effects
                StartCoroutine(PoofParticles());
                DisplayEndState();
                break;
            default:
                break;
        }
        mBirdyState = newBirdyState;
    }

    private IEnumerator Takeoff()
    {
        //speed up
        yield return new WaitForSeconds(1);
        //switch to free control
        SetBirdyState(BirdyState.Flying);
    }

    private IEnumerator PoofParticles()
    {
        particleHolder.SetActive(true);
        as1.Play();
        as2.Play();
        yield return new WaitForSeconds(3f);

        particleHolder.SetActive(false);
    }

    //For collisions 
    private void OnCollisionEnter(Collision collision)
    {
        //Check tag of object 
        FindObjectOfType<GameManager>().EndGame();

        //Change audio
        //FindObjectOfType<AudioManager>().Play();
    }

    private void DisplayEndState()
    {
        GameStateManager.Instance.CueWaitAndLoad("MainMenu2", 5f);
    }
}
