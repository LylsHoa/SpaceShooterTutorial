using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //ARRAY; Basically a list. So a list of hazards.
    public GameObject[] hazards;

    public Vector3 spawnValues;

    public int hazardCount;
  
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;

    public Text gameoverText;

    public Text restartText; 

    private float score;

    private bool isgameover;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SpawnWaves());

        scoreText.text = "";

        score = 0;

        gameoverText.text = "";

        isgameover = false;

        restartText.text = "";

	}

    public void AddScore (float Amount)
    {
        score = score + Amount;
    }

    public void gameover ()
    {
        gameoverText.text = "GAME OVER!";

        restartText.text = "Press 'R' to Restart";



        isgameover = true;
    }


	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
     

        }

        if (isgameover && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("Main");
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
                //picks at random from our hazards list
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];

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
