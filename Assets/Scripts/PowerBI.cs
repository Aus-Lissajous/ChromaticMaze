using UnityEngine;
using System.Collections;

public class PowerBI : MonoBehaviour {

	public BinaryImager myShader;
	public PowerBI esteScript;
	public Collider boxCol;

	void DetenerScript()
	{
		esteScript.enabled = false;
		CancelInvoke("incrementarScale");
		CancelInvoke("menosScale");
		myShader.ditherScale = 1;
//		Game_Manager.Instance.Correcto ();
		myShader.enabled = false;

	}
	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player") 
		{
			InvokeRepeating ("incrementarScale", 0.1f, 0.1f);
			Invoke("DetenerScript", 2);
			//Game_Manager.Instance.Correcto ();
			myShader.enabled = true;
			boxCol.enabled = false;
		}
	}
	void incrementarScale()
	{
		myShader.ditherScale += 1;

		if (myShader.ditherScale > 4) 
		{
			CancelInvoke("incrementarScale");
			InvokeRepeating ("menosScale", 0.1f, 0.1f);
		}
	}
	void menosScale()
	{
		myShader.ditherScale -= 1;

		if (myShader.ditherScale < 0) 
		{
			CancelInvoke("menosScale");
			InvokeRepeating ("incrementarScale", 0.1f, 0.1f);
		}
	}
}