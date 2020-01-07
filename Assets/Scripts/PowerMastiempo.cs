using UnityEngine;
using System.Collections;

public class PowerMastiempo : MonoBehaviour {
	public Collider boxCol;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider col)
	{

		if (col.gameObject.tag == "Player") 
		{
			Game_Manager.Instance.tiempoExtra (5);
			boxCol.enabled = false;
			Game_Manager.Instance.Correcto ();
		}
	}
}
