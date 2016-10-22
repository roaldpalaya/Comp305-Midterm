/*Midterms
 * Roald Russel T. Palaya
 * 300714999
 * Date last Modified: 10/22/2016
 */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour {
    //PRIVATE INSTANCE VARIABLES
    private int _lives;
    private int _score;

    // PUBLIC INSTANCE VARIABLES
    public int enemyCount;
	public GameObject enemy;
    public Text LivesLbl;
    public Text ScoreLbl;

    public AudioSource EndSound;

    public int Lives
    {
        get
        {
            return this._lives;
        }
        set
        {
            this._lives = value;
            if (this._lives <= 0)
            {
                EndSound.Play();
                this._endGame();

            }
            else
            {
                this._lives = value;
                this.LivesLbl.text = "Lives: " + this._lives;
            }
        }
    }
    public int Score
    {
        get
        {
            return this._score;
        }
        set
        {
            this._score = value;
            this.ScoreLbl.text = "Score: " + this._score;
        }
    }

    // Use this for initialization
    void Start () {
		this._GenerateEnemies ();
        this._lives = 5;
        this._score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// generate Clouds
	private void _GenerateEnemies() {
		for (int count=0; count < this.enemyCount; count++) {
			Instantiate(enemy);
		}
	}
    private void _endGame()
    {

        SceneManager.LoadScene("ResetScene");
    }
}
