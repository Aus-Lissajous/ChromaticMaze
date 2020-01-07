using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inicia : MonoBehaviour
{

    // Use this for initialization
    public GameObject Fondo;
    public GameObject Chromatic_Maze;
    public GameObject Nombres;
    public GameObject Universidad_Iberoamericana;
    public float Conta_Intro = 20f;
    public GameObject Boton_Start;

    void Update()
    {
        //Contado de introduccion donde los game objects van desplazandose atravez de la pantalla principal en determinados tiempos
        Conta_Intro -= Time.deltaTime;
        // Pasar Valor a Enter
        int CountDown;
        CountDown = Mathf.FloorToInt(Conta_Intro);
        // switch Statement

        switch (CountDown)
        {
            case 18:
                Contador_1();
                break;
            case 15:
                Contador_2();
                break;
            case 13:
                Contador_3();
                break;
            case 7:
                Contador_4();
                break;
            case 6:
                Contador_0();
                Contador_5();
                break;
            case 0:
                Debug.Log("Todas las funciones fueron llamads");
                //En este punto el tiempo es 0
                break;
            default:
                break;
        }
    }

    public void Contador_0()
    {
        Chromatic_Maze.transform.DOScale(0f, 2f);
        Nombres.transform.DOScale(0f, 2f);
    }
    public void Contador_1()
    {
        Chromatic_Maze.transform.DOMoveY(0f, 2f);
    }
    public void Contador_2()
    {
        Nombres.transform.DOMoveY(0f, 2f);
    }
    public void Contador_3()
    {
        Universidad_Iberoamericana.transform.DOMoveY(0f, 2f);
    }
    public void Contador_4()
    {
        Universidad_Iberoamericana.transform.DOMoveX(50f, 2f);
    }
    public void Contador_5()
    {
        Boton_Start.transform.DOMoveY(0f, 1f);
    }
    public void Boton()
    {
        // Este metodo de Load Scene no carga la escena en back ground a diferencia del LoadSceneAsync
        SceneManager.LoadScene("Escenas/Escena1");
        //Obsoleto
        //Application.LoadLevel("Escenas/Escena1");
    }
}