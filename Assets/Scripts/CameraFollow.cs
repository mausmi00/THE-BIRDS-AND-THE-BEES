using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 offset = new Vector3(5, 0, 0);
    public GameObject target;

    private float mainSize = 5f;
    private float zoomedSize = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = gameObject.transform.position;
        newPosition.x = target.transform.position.x;
        newPosition += offset;
        gameObject.transform.position = newPosition;
    }
}
