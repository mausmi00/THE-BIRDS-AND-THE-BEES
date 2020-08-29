using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public enum EnemyState
{
    Wait,
    Alert,
    Jumping
};

public class EnemyCat : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject mCatObject;
    private Vector3 defaultPosition;
    private EnemyState mState = EnemyState.Wait;
    private float mVertSpeed = 6f;
    private float mHorSpeed = -2f;
    [SerializeField] private Animator mCatAnimator;


    void Start()
    {
        defaultPosition = mCatObject.transform.position;
        mState = EnemyState.Alert;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (mState == EnemyState.Alert)
        {
            mState = EnemyState.Jumping;
            StartCoroutine(JumpToHeight(0f));
        }
        
    }

    public void Jump(float height)
    {
        if (mState == EnemyState.Alert)
        {
            mState = EnemyState.Jumping;
            StartCoroutine(JumpToHeight(height));
        }
    }

    public IEnumerator JumpToHeight(float targetHeight)
    {
        Vector3 nextPosition = mCatObject.transform.position;
        //jump up
        //Debug.Log("jump up");
        UpdateAnimation(1f, true, true);
        while (mCatObject.transform.position.y < targetHeight)
        {
            nextPosition.x += mHorSpeed * Time.deltaTime;
            nextPosition.y += mVertSpeed * Time.deltaTime;
            mCatObject.transform.position = nextPosition;
            yield return new WaitForEndOfFrame();
        }

        //hang out on top
        //Debug.Log("stay up");
        UpdateAnimation(0f, true, true);
        yield return new WaitForSeconds(0.15f);
        //jump down
        //Debug.Log("jump down");
        UpdateAnimation(-1f, true, true);
        while (mCatObject.transform.position.y > transform.position.y)
        {
            nextPosition.x += mHorSpeed * Time.deltaTime;
            nextPosition.y -= mVertSpeed * Time.deltaTime;
            mCatObject.transform.position = nextPosition;
            yield return new WaitForEndOfFrame();
        }
        //land
        //Debug.Log("land");
        UpdateAnimation(0f, false, true);
        nextPosition.y = transform.position.y;
        mCatObject.transform.position = nextPosition;
        mState = EnemyState.Alert;
        //return to unalert
        yield return new WaitForSeconds(2f);
        UpdateAnimation(0f, false, false);
        mState = EnemyState.Wait;

    }
    public void Reset()
    {
        mState = EnemyState.Wait;
        mCatObject.transform.position = transform.position;
    }
    public void Alert()
    {
        mState = EnemyState.Alert;
        UpdateAnimation(0f, false, true);
    }

    private void UpdateAnimation(float vMotion, bool jumping, bool alert)
    {
        mCatAnimator.SetFloat("VertSpeed", vMotion);
        mCatAnimator.SetBool("Alert", alert);
        mCatAnimator.SetBool("Jumping", jumping);
    }
}
