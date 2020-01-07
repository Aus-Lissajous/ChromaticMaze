using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour {

	public Text Score;
	public Text HighScore;
	public Text Score_2;
	public Text HighScore_2;
	private float Conta_GameOver;
	public GameObject GameOver;
	public GameObject Scores;
	public GameObject Mensaje;
	public GameObject Boton_Try_Again;

	// Use this for initialization
	void Start () {
		Conta_GameOver = 20;
		Score.text = "SCORE: " + Game_Manager.Instance.Score;
		HighScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("Highscore");
		Score_2.text = "SCORE: " + Game_Manager.Instance.Score;
		HighScore_2.text = "HIGH SCORE: " + PlayerPrefs.GetInt("Highscore");
	}
	
	// Update is called once per frame
	void Update () 
	{
		Conta_GameOver -= Time.deltaTime;
        int CountDown;
        CountDown = Mathf.FloorToInt(Conta_GameOver);
        // Para este otro caso fue mas facil solo poner las transiciones directamente a comparacion con el script de inciar
        switch (CountDown)
        {
            case 20:
                GameOver.transform.DOMoveY(0f, 1f);
                break;
            case 15:
                Scores.transform.DOMoveY(0f, 2f);
                break;
            case 13:
                Mensaje.transform.DOMoveY(0f, 2f);
                break;
            case 7:
                Mensaje.transform.DOMoveX(50f, 2f);
                break;
            case 6:
                GameOver.transform.DOScale(0f, 2f);
                Scores.transform.DOScale(0f, 2f);
                Boton_Try_Again.transform.DOMoveY(0f, 1f);
                break;
            case 0:
                Debug.Log("Todas las transiciones fueron hechas");
                //En este punto el tiempo es 0
                break;
            default:
                break;
        }
	}
	
	
	public void Boton()
	{
        SceneManager.LoadScene("Escenas/Escena1");
		//Application.LoadLevel("Escena1");
	}
}