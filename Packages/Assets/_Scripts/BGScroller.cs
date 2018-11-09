using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;





	// Use this for initialization
	void Start ()
    {
        //Want to start @transform.position not 0 b/c 3D game & z is -10
        startPosition = transform.position;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        //To Repeat the position of the background; 
        //cycles through the two tiles endlessly over time & controlled by scroll speed and what we repeating? --> tilesizez
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);

        transform.position = startPosition + Vector3.forward * newPosition;
	}
}
