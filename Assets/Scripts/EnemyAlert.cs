using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlert : MonoBehaviour
{
    [SerializeField] private EnemyCat mEnemyCat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            mEnemyCat.Alert();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            mEnemyCat.Jump(col.transform.position.y);
        }
    }
}
