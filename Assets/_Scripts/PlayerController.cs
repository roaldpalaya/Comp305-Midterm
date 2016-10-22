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

    [Header("audio source")]
    public AudioSource ExplosionSound;
    
    //play explosion
    public Transform explosion;

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
        this._gController.Lives = 5;
        this._gController.Score = 0;
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Contains("Enemy"))
        {
            this._gController.Lives -= 1;
            this.ExplosionSound.Play();
            if (explosion)
            {
                Debug.Log("exploding");
                GameObject exploder = ((Transform)Instantiate(explosion, this.transform.position, this.transform.rotation)).gameObject;
                //exploder.GetComponent<Renderer>().
                exploder.GetComponent<Renderer>().sortingLayerName = "Default";

                Destroy(exploder, 2.0f);
            }
            Debug.Log("Ship hit Lives left: " + this._gController.Lives);
            this._newPosition = gameObject.GetComponent<Transform>().position;
        }
    }
}
