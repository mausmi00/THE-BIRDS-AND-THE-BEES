using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public GameObject[] tracks;
    private int tracksToNextBirdhouse = 3;
    private int tracksDeployedCounter = 0;
    public float trackLength = 30f;

    public Birdhouse mBirdhouse;

    private int currentTrack = 0;
    private int lastTrack = 1;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNextTrack()
    {
        ++tracksDeployedCounter;
        float nextXPos = tracks[currentTrack].transform.position.x + trackLength;
        //++currentTrack;
        //if (currentTrack > (tracks.Length - 1)){
        //    currentTrack = 0;
        //}
        int nextTrack = GetRandomTrackNumber();
        lastTrack = currentTrack;
        currentTrack = nextTrack;
        Vector3 nextPos = tracks[currentTrack].transform.position;
        nextPos.x = nextXPos;
        tracks[currentTrack].transform.position = nextPos;
        tracks[currentTrack].GetComponent<Track>().Spawn();
        if (tracksDeployedCounter >= tracksToNextBirdhouse)
        {
            DeployBirdhouse();
        }

    }

    public int GetRandomTrackNumber()
    {
        int rand = Random.Range(0, tracks.Length);
        while (rand == currentTrack || rand == lastTrack) //redraw until you get a new one
        {
            rand = Random.Range(0, tracks.Length);
        }
        Debug.Log("Random track: " + rand + "/" +tracks.Length);
        return rand;
    }
    private void DeployBirdhouse()
    {
        tracksDeployedCounter = 0;
        tracksToNextBirdhouse = Mathf.CeilToInt(tracksToNextBirdhouse * 1.2f);
        mBirdhouse.Place(tracks[currentTrack].GetComponent<Track>().birdhousePosition.position);
    }

 

}
