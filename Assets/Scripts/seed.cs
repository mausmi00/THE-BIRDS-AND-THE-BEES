using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class seed : MonoBehaviour
{
    // Start is called before the first frame update
    private int seedValue = 1;
    private int seedHealth = 90;
    public playerHealth playerHealth;
    public SpriteRenderer mRenderer;

    void Awake()
    {
        if (playerHealth == null)
        {
            playerHealth = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<playerHealth>();
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Player")
        {
            Debug.Log("player has collected the seed");
            Destroy(gameObject);
            playerHealth.changeSliderValue();
            mRenderer.enabled = false;
            // Debug.Log("seed destroyed");
            // c.gameObject.GetComponent<MeshRenderer>().enabled = false;
            
        }
        
    }
    void Start()
    {
        //rend = GetComponent<CapsuleCollider>();
        //rend2 = GetComponent<Renderer>();

        //gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //yield return new WaitForSeconds(5);
    }
    IEnumerator Time()
    {
        yield return new WaitForSeconds(3f);
        //rend.enabled = false;
        //rend2.enabled = false;
        yield return new WaitForSeconds(5f);
        //rend.enabled = true;
        //rend2.enabled = true;



    }

    
    
}
