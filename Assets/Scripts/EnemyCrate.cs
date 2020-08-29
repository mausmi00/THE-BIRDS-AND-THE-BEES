using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrate : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject mCrateHolder;
    private Vector3 mOffset;

    private float minY = 2.5f;
    private float maxY = 5f;

    private float targetY;

    private float xSpeed = -1f;
    private float ySpeed = 1f;

    private float closeEnough = 0.1f;

    void Awake()
    {
        mCrateHolder = gameObject.transform.GetChild(0).gameObject;
        mOffset = mCrateHolder.transform.position - gameObject.transform.position;
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCrate();
    }

    private void Initialize()
    {
        MoveBackIntoBounds();
        xSpeed = Random.Range(-0.5f, 0.5f);
        GetNewTargetY();
    }

    private void MoveCrate()
    {
        //Debug.Log(mCrateHolder.transform.position + " -> " + targetY);
        Vector3 newPosition = mCrateHolder.transform.position;
        newPosition.x += xSpeed * Time.deltaTime;
        if ((targetY-closeEnough) > newPosition.y)
        {
            newPosition.y += ySpeed * Time.deltaTime;
        }
        else if ((targetY+closeEnough) < newPosition.y)
        {
            newPosition.y -= ySpeed * Time.deltaTime;
        }
        else
        {
            //you're close enough - find new target
            GetNewTargetY();
        }
        mCrateHolder.transform.position = newPosition;
    }

    private void GetNewTargetY()
    {
        ySpeed = Random.Range(0.25f, 0.7f);
        targetY = Random.Range(minY, maxY);
    }

    private void MoveBackIntoBounds()
    {
        Vector3 newPosition = transform.position;
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        transform.position = newPosition;

    }
}
