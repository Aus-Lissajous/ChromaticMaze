using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class Colores : MonoBehaviour
{

    public Color[] colores;

    void Start()
    {
        StartCoroutine(Color_aleatorio());
    }

    IEnumerator Color_aleatorio()
    {
        //Obtiene el componente del boton de comenzar el cual va cambiando de coloroes aleatoriamente.
        GetComponent<Button>().image.DOColor(colores[Random.Range(0, colores.Length)], 1F);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Color_aleatorio());
    }
}