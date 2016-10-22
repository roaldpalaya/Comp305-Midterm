/*Midterms
 * Roald Russel T. Palaya
 * 300714999
 * Date last Modified: 10/22/2016
 */


using UnityEngine;
using System.Collections;

[System.Serializable]
public class Speed {
	public float minSpeed, maxSpeed;
}

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}


public class EnemyController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public Speed speed;
	public Boundary boundary;

	// PRIVATE INSTANCE VARIABLES
	private float _CurrentSpeed;
	private float _CurrentDrift;
    private GameObject _gControllerObject;
    private GameController _gController;

    // Use this for initialization
    void Start () {
		this._Reset ();
        this._init();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.y -= this._CurrentSpeed;
		gameObject.GetComponent<Transform> ().position = currentPosition;
		
		// Check bottom boundary
		if (currentPosition.y <= boundary.yMin) {
			this._Reset();
		}
        this._Score();
	}
    //init
    private void _init()
    {

        this._gControllerObject = GameObject.Find("GameController");
        this._gController = this._gControllerObject.GetComponent<GameController>() as GameController;

    }

    // resets the gameObject
    private void _Reset() {
		this._CurrentSpeed = Random.Range (speed.minSpeed, speed.maxSpeed);
		Vector2 resetPosition = new Vector2 (Random.Range(boundary.xMin, boundary.xMax), boundary.yMax);
		gameObject.GetComponent<Transform> ().position = resetPosition;

    }

    //check if the enemy ship hits the player
    private void _Score() {
        Vector2 currentPosition = gameObject.GetComponent<Transform>().position;
        currentPosition.y -= this._CurrentSpeed;
        gameObject.GetComponent<Transform>().position = currentPosition;

        // Check bottom boundary
        if (currentPosition.y <= boundary.yMin)
        {
            this._gController.Score += 10;
            Debug.Log("Score is: " + this._gController.Score);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {
            Debug.Log("Resetting enemy");
            this._Reset();
            this._gController.Lives -= 1;
        }
    }

}
