using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class Control_UI : MonoBehaviour {

	public GameObject Fondo;
	public GameObject Chromatic_Maze;
	public GameObject Nombres;
	public GameObject Universidad_Iberoamericana;
	public float Conta_Intro = 20f;
	public GameObject Boton_Start;

	// Use this for initialization
	void Update () 
	{
		Conta_Intro -= Time.deltaTime;
	
	if (Conta_Intro <= 18)
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
			Chromatic_Maze.transform.DOScale (0f, 2f);
			Nombres.transform.DOScale(0f, 2f);
		}		
	public void Contador_1()
		{
			Chromatic_Maze.transform.DOMoveY (0f, 2f);
		}
	public void Contador_2()
		{
			Nombres.transform.DOMoveY (0f, 2f);
		}
	public void Contador_3()
		{
			Universidad_Iberoamericana.transform.DOMoveY (0f, 2f);
		}
	public void Contador_4()
		{
			Universidad_Iberoamericana.transform.DOMoveX(50f,2f);
		}
	public void Contador_5 ()
		{
			Boton_Start.transform.DOMoveY (0f, 1f);
		}
	public void Boton()
		{
			Application.LoadLevel("Escena1");
		}
}