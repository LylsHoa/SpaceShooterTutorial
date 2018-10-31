using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;

    public Vector3 spawnValues;

    public int hazardCount;
  
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;

    private float score; 


	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SpawnWaves());

        scoreText.text = "";

        score = 0;

	}

    public void AddScore ()
    {
        score = score + 10;

        
    }


	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();

     

        }

        scoreText.text = "Score : " + score;


    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);

        //INFINITE LOOP
        while (true)
        {

            //FOR LOOP
            for (int I = 0; I < hazardCount; I++)
            {

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                //wait then spawn
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);
        }

    }
}
