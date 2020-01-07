using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;


public class Colores_Panel : MonoBehaviour {
	public Color[] colores;
	
	void Start () 
	{
		StartCoroutine (Color_aleatorio ());
	}
	IEnumerator Color_aleatorio()
	{
		GetComponent<SpriteRenderer> ().DOColor (colores[Random.Range(0,colores.Length)], 1f);
		yield return new WaitForSeconds(2f);
		StartCoroutine (Color_aleatorio ());
	}
}