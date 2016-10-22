/*Midterms
 * Roald Russel T. Palaya
 * 300714999
 * Date last Modified: 10/22/2016
 */


using UnityEngine;

using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class ResetController : MonoBehaviour {
    private int _score;
    private int _Hscore;

    public Text ScoreLbl;
    public Text HscoreLbl;
    public int hScore
    {
        get
        {
            return this._Hscore;
        }
        set
        {
            this._Hscore = value;
            if (this._Hscore <= 0)
            {
                //this._endGame();

            }
            else
            {
                this._Hscore = value;
                this.HscoreLbl.text = "Lives: " + this._Hscore;
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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Start_Click()
    {
        SceneManager.LoadScene("Main");
    }

}
