using UnityEngine;
using System.Collections;

public class EditorBinaryImage : MonoBehaviour {
	public BinaryImager myShader;
    //Efecto simple para animar el shader

	void Start () {
		InvokeRepeating ("CambiaShader", 0.1f, 0.1f);
	}
	void CambiaShader()
	{
		myShader.blendFactor += 0.01f;

		if (myShader.blendFactor > 0.50f) 
		{
			CancelInvoke("CambiaShader");
			InvokeRepeating ("CambiaShader2", 0.1f, 0.1f);
		}
	}
	void CambiaShader2()
	{
		myShader.blendFactor -= 0.01f;

		if(myShader.blendFactor < 0)
		{
			CancelInvoke("CambiaShader2");
			InvokeRepeating ("CambiaShader", 0.1f, 0.1f);
		}
	}
}