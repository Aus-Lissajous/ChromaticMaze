using UnityEngine;
using System.Collections;

public class Jugador : MonoBehaviour {


	public float magnitude;
	void Update () {
		//coordenadas locales apuntando direccion x
		Vector3 izquierda = -transform.right;
		Vector3 derecha = transform.right; // ala izquierda
		Vector3 arriba = transform.up; // arriba
		Vector3 abajo = -transform.up; // abajo
		//Vector3 DerechaArriba = transform.right + transform.up;
		//dibujo el rayo
		//Debug.DrawRay (transform.position, (transform.right + transform.up) * Magnitud_Diagonal);
		Debug.DrawRay(transform.position,transform.right*magnitude);
		Debug.DrawRay(transform.position,-transform.right*magnitude);
		Debug.DrawRay(transform.position,transform.up*magnitude);
		Debug.DrawRay(transform.position,-transform.up*magnitude);
		RaycastHit hit;

		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			//! negado preguntar lo contrario ,si no choco me muevo
			if(Physics.Raycast(transform.position, arriba, out hit, magnitude))
			{
				if (hit.transform.gameObject.tag != "Pared")
				{
					transform.Translate(0,0.1f,0);
				}
			}
			else 
			{
				transform.Translate(0,0.1f,0);
			}
		}
		
		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			if(Physics.Raycast(transform.position, abajo, out hit, magnitude))
			{
				if (hit.transform.gameObject.tag != "Pared")
				{
				transform.Translate(0,-0.1f,0);
			
				}
			}
				else 
				{
					transform.Translate(0,-0.1f,0);
				}
		}
		
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			if(Physics.Raycast(transform.position, derecha, out hit, magnitude))
			{
				if (hit.transform.gameObject.tag != "Pared")
				{
				transform.Translate(0.1f,0,0);
				
				}
			}
				else 
				{
					transform.Translate(0.1f,0,0);
				}
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			if(Physics.Raycast(transform.position, izquierda, out hit, magnitude))
			{
				if (hit.transform.gameObject.tag != "Pared")
				{
				transform.Translate(-0.1f,0,0);
				
				}
			}
				else 
				{
					transform.Translate(-0.1f,0,0);
				}
		}
	}
	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag =="Puerta")
		{
			Game_Manager.Instance.Carga_Niveles();
			Game_Manager.Instance.Correcto();
		}

	}

}
