using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public float scoreWorth;

    //found game controller to record points
    private GameController gameController;

    void Start()
    {


        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Boundary") || other.CompareTag ("Enemy"))
        {
            return;
        }

        // != not equals
        //If we have the explosion, THEN we instantiate it
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        //if we crash
        if (other.CompareTag ("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

            //call func w/ ()
            gameController.gameover();
        }
        else
        {
            //if the thing we crashing into = player then don't add score
            gameController.AddScore(scoreWorth);
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
        
	
}
