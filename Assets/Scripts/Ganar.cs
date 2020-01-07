using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ganar : MonoBehaviour {
	
	public GameObject Fondo;
	public GameObject Game_Finish;
	public GameObject Scores;
	public Text Score_1;
	public Text Score_2;
	public Text High_Score_1;
	public Text High_Score_2;
	public GameObject Mensaje;
	private float Conta_Intro = 20f;
	public GameObject Boton_Play_Again;
	
	// Use this for initialization
	void Update () 
	{
		Conta_Intro -= Time.deltaTime;

        // asi funcionaria usando el else if , en vez del switch , en mi caso es mas elegante con los cases
        if (Conta_Intro <= 20)
		{
			Contador_1();
		}
		if (Conta_Intro <= 15)
		{
			Contador_2();
		}
		if (Conta_Intro <= 13)
		{
			Contador_3();
		}
		if (Conta_Intro<=7)
		{
			Contador_4();
			Contador_0();
		}	
		if (Conta_Intro <= 6)
		{
			Contador_5();
		}
		if (Conta_Intro <= 0)
		{
			//Contador_5();
		}
	}
	
	public void Contador_0 ()
	{
		Game_Finish.transform.DOScale (0f, 2f);
		Scores.transform.DOScale(0f, 2f);
	}		
	public void Contador_1()
	{
		Game_Finish.transform.DOMoveY (0f, 2f);
	}
	public void Contador_2()
	{
		Scores.transform.DOMoveY (0f, 2f);
	}
	public void Contador_3()
	{
		Mensaje.transform.DOMoveY (0f, 2f);
	}
	public void Contador_4()
	{
		Mensaje.transform.DOMoveX(50f,2f);
	}
	public void Contador_5 ()
	{
		Boton_Play_Again.transform.DOMoveY (0f, 1f);
	}
	public void Boton()
	{
        SceneManager.LoadScene("Escenas/Escena1");
	}
}