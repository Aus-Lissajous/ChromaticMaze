using UnityEngine;
using System.Collections;

public class PowerMasScore : MonoBehaviour {

	public Collider boxCol;
	
	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player") 
		{
			Game_Manager.Instance.maspuntos (5);
			Game_Manager.Instance.Correcto ();
			boxCol.enabled = false;
		}
	}
}