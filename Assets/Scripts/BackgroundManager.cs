using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject background1;
    public GameObject background2;

    private float tileDistance;
    private float moveSpeed = 2f;

    private float driftCounter = 0;

    private GameObject targetObj;

    private bool isMoving = false;

    // Start is called before the first frame update
    void Awake()
    {
        tileDistance = background2.transform.position.x - background1.transform.position.x;
        targetObj = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            background1.transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            background2.transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            if (targetObj.transform.position.x > background1.transform.position.x && targetObj.transform.position.x > background2.transform.position.x)
            {
                MoveNextTileIntoPosition();
            }
        }
    }

    private void MoveNextTileIntoPosition()
    {
        if (background1.transform.position.x < background2.transform.position.x)
        {
            Vector3 newPosition = background2.transform.position;
            newPosition.x += tileDistance;
            background1.transform.position = newPosition;
        }
        else
        {
            Vector3 newPosition = background1.transform.position;
            newPosition.x += tileDistance;
            background2.transform.position = newPosition;
        }
    }

    public void Freeze()
    {
        isMoving = false;
    }

    public void Unfreeze()
    {
        isMoving = true;
    }
}
