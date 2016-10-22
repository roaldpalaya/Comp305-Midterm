/*Midterms
 * Roald Russel T. Palaya
 * 300714999
 * Date last Modified: 10/22/2016
 */


using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES +++++++++++++++++++++++++++++++++++++++
	//public float speed;
	public Boundary boundary;

	public Camera camera;
	
	// PRIVATE INSTANCE VARIABLES
	private Vector2 _newPosition = new Vector2(0.0f, 0.0f);
    private GameObject _gControllerObject;
    private GameController _gController;
    // Use this for initialization
    void Start () {
        this._init();
	}

	// Update is called once per frame
	void Update () {
		this._CheckInput ();
	}
    private void _init()
    {

        this._gControllerObject = GameObject.Find("GameController");
        this._gController = this._gControllerObject.GetComponent<GameController>() as GameController;

    }
    private void _CheckInput() {
		this._newPosition = gameObject.GetComponent<Transform> ().position; // current position

		/* movement by keyboard
		if (Input.GetAxis ("Horizontal") > 0) {
			this._newPosition.x += this.speed; // add move value to current position
		}
	
		
		if (Input.GetAxis ("Horizontal") < 0) {
			this._newPosition.x -= this.speed; // subtract move value to current position
		}
		*/

		// movement by mouse
		Vector2 mousePosition = Input.mousePosition;
		this._newPosition.x = this.camera.ScreenToWorldPoint (mousePosition).x;

		this._BoundaryCheck ();

		gameObject.GetComponent<Transform>().position = this._newPosition;
	}

	private void _BoundaryCheck() {
		if (this._newPosition.x < this.boundary.xMin) {
			this._newPosition.x = this.boundary.xMin;
		}

		if (this._newPosition.x > this.boundary.xMax) {
			this._newPosition.x = this.boundary.xMax;
		}
	}
    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag.Contains("Enemy"))
        {
            this._gController.Lives -= 1;
            Debug.Log("Ship hit Lives left: " + this._gController.Lives);
        }
    }
}
