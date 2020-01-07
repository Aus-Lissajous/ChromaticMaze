using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class Game_Manager : MonoBehaviour
{
    //Singleton para tener acceso al game manager desde cualquier script
    public static Game_Manager Instance { get; private set; }
    public List<GameObject> NivelesDelJuego;
    public Text Vidas;
    public int Niveles = 0;
    public AudioSource MFondo;
    public AudioSource Falso;
    public AudioSource Verdadero;
    //Llevar el Tiempo
    public Text Tiempo;
    private int llevaTiempo;
    //Llevar Score
    public Text ScoreText;
    public int Score;
    private int vidas;
    //Llevar el highscore
    public Text HighScoreText;
    public int highscore;
    public int puntajes;
    //Funcion para las vidas
    public List<GameObject> VidasObjetos;

    public void UpdateVidas()
    {
        //Al tener 3 vidas las imagenes estaran en la UI
        //Comienzas con 3 Vidas en el juego

        switch (vidas)
        {
            case 3:
                for (int i = 0; i < VidasObjetos.Count; i++)
                {
                    //Todas las vidas estan Activas
                    VidasObjetos[i].SetActive(true);
                }
                break;
            case 2:
                VidasObjetos[vidas].SetActive(false);
                break;
            case 1:
                VidasObjetos[vidas].SetActive(false);
                break;
            case 0:
                VidasObjetos[vidas].SetActive(false);
                Debug.Log("Las Vidas se acabaron");
                CancelInvoke("menostiempo");
                MFondo.Stop();
                Invoke("Cargar_GameOver", 4.0f);
                break;
            default:
                break;
        }
    }
    void Awake()
    {
        Score = 0;
        Instance = this;
        vidas = 3;
        int highscore = PlayerPrefs.GetInt("Highscore");
        HighScoreText.text = "High score: " + highscore;
        Texto_Tiempo_Normal();
    }

    public void QuitarVida()
    {
        vidas--;
    }
    void Start()
    {
        MusicaDeFondo();
        llevaTiempo = 10;
        InvokeRepeating("menostiempo", 1, 1);
    }

    public void maspuntos(int nuevoScore)
    {
        Score = Score + nuevoScore;
        int highscore = PlayerPrefs.GetInt("Highscore");
        if (Score > highscore)
        {
            highscore = Score;
            PlayerPrefs.SetInt("Highscore", highscore);
            HighScoreText.text = "High score: " + highscore;
        }
        ScoreText.text = "Score: " + Score;
        Anima_Texto();
    }
    void menostiempo()
    {
        llevaTiempo--;
        //para convertir numero a un string ""+
        Tiempo.text = "Tiempo: " + llevaTiempo;
        PantallaPerdiste();
        Regresiva();
    }
    public void tiempoExtra(int masTiempo)
    {
        llevaTiempo += masTiempo;
    }
    public void Anima_Texto()
    {
        ScoreText.transform.DOScale(4f, 0.3f);
        ScoreText.transform.DOScale(1f, 0.3f);
    }
    public void Anima_Texto_Tiempo()
    {
        Tiempo.transform.DOScale(4f, 0.3f);
        Tiempo.transform.DOScale(1f, 0.3f);
        Tiempo.color = Color.red;
    }

    public void Texto_Tiempo_Normal()
    {
        Tiempo.color = Color.white;
    }
    public void Regresiva()
    {
        if (llevaTiempo <= 5)
        {
            Anima_Texto_Tiempo();
        }
        else
        {
            Texto_Tiempo_Normal();
        }
    }

    void PantallaPerdiste()
    {
        if (llevaTiempo == 0)
        {
            Game_Manager.Instance.QuitarVida();
            Game_Manager.Instance.UpdateVidas();
            Game_Manager.Instance.Incorrecto();
            if (Niveles == 0)
            {
                llevaTiempo = 10;
            }
            else if (Niveles == 1)
            {
                llevaTiempo = 10;
            }
            else if (Niveles == 2)
            {
                llevaTiempo = 10;
            }
            else if (Niveles == 3)
            {
                llevaTiempo = 15;
            }
            else if (Niveles == 4)
            {
                llevaTiempo = 15;
            }
            else if (Niveles == 5)
            {
                llevaTiempo = 20;
            }
            else if (Niveles == 6)
            {
                llevaTiempo = 20;
            }
            else if (Niveles == 7)
            {
                llevaTiempo = 20;
            }
            else if (Niveles == 8)
            {
                llevaTiempo = 25;
            }
            else if (Niveles == 9)
            {
                llevaTiempo = 25;
            }
            else if (Niveles == 10)
            {
                llevaTiempo = 25;
            }
            else if (Niveles == 11)
            {
                llevaTiempo = 30;
            }
            else if (Niveles == 12)
            {
                llevaTiempo = 30;
            }
            else if (Niveles == 13)
            {
                llevaTiempo = 30;
            }
            else if (Niveles == 14)
            {
                llevaTiempo = 35;
            }
            else if (Niveles == 15)
            {
                llevaTiempo = 35;
            }
            else if (Niveles == 16)
            {
                llevaTiempo = 35;
            }
            else if (Niveles == 17)
            {
                llevaTiempo = 35;
            }
            else if (Niveles == 18)
            {
                CancelInvoke("menostiempo");
            }
        }
    }
    void CargarNivel()
    {
        SceneManager.LoadScene("Escenas/Escena1");
        // quedo deprecado en Application.LoadLevel
        //Application.LoadLevel ("Escena1");
    }

    void Cargar_GameOver()
    {
        SceneManager.LoadScene("Escenas/Game_Over");
        // quedo deprecado en Application.LoadLevel
        //Application.LoadLevel ("Game_Over");
    }

    public void Carga_Niveles()
    {
        //Abreviatura de summar nivel + nivel
        //Aqui vamos a ir cambiando los niveles o laberintos del juego 
        Niveles++;
        //Niveles 18 en total
        switch (Niveles)
        {
            case 0:
                for (int i = 0; i < NivelesDelJuego.Count; i++)
                {
                    //Todas las vidas estan Activas
                    NivelesDelJuego[i].SetActive(false);
                }
                NivelesDelJuego[Niveles].SetActive(true);
                maspuntos(5);
                break;
            case 1:
                for (int i = 0; i < NivelesDelJuego.Count; i++)
                {
                    //Todas las vidas estan Activas
                    NivelesDelJuego[i].SetActive(false);
                }
                NivelesDelJuego[Niveles].SetActive(true);
                maspuntos(10);
                //El tiempo que te puede llevar completar un Laberinto
                llevaTiempo = 10;
                break;
            case 2:
                for (int i = 0; i < NivelesDelJuego.Count; i++)
                {
                    //Todas las vidas estan Activas
                    NivelesDelJuego[i].SetActive(false);
                }
                NivelesDelJuego[Niveles].SetActive(true);
                maspuntos(15);
                //El tiempo que te puede llevar completar un Laberinto
                llevaTiempo = 15;
                break;
            case 3:
                for (int i = 0; i < NivelesDelJuego.Count; i++)
                {
                    //Todas las vidas estan Activas
                    NivelesDelJuego[i].SetActive(false);
                }
                NivelesDelJuego[Niveles].SetActive(true);
                maspuntos(20);
                //El tiempo que te puede llevar completar un Laberinto
                llevaTiempo = 15;
                break;
            case 4:
                for (int i = 0; i < NivelesDelJuego.Count; i++)
                {
                    //Todas las vidas estan Activas
                    NivelesDelJuego[i].SetActive(false);
                }
                NivelesDelJuego[Niveles].SetActive(true);
                maspuntos(25);
                //El tiempo que te puede llevar completar un Laberinto
                llevaTiempo = 20;
                break;
            case 5:
                for (int i = 0; i < NivelesDelJuego.Count; i++)
                {
                    //Todas las vidas estan Activas
                    NivelesDelJuego[i].SetActive(false);
                }
                NivelesDelJuego[Niveles].SetActive(true);
                maspuntos(30);
                //El tiempo que te puede llevar completar un Laberinto
                llevaTiempo = 20;
                break;
            case 6:
                for (int i = 0; i < NivelesDelJuego.Count; i++)
                {
                    //Todas las vidas estan Activas
                    NivelesDelJuego[i].SetActive(false);
                }
                NivelesDelJuego[Niveles].SetActive(true);
                maspuntos(35);
                //El tiempo que te puede llevar completar un Laberinto
                llevaTiempo = 20;
                break;
            case 7:
                for (int i = 0; i < NivelesDelJuego.Count; i++)
                {
                    //Todas las vidas estan Activas
                    NivelesDelJuego[i].SetActive(false);
                }
                NivelesDelJuego[Niveles].SetActive(true);
                maspuntos(40);
                //El tiempo que te puede llevar completar un Laberinto
                llevaTiempo = 20;
                break;
            case 8:
                for (int i = 0; i < NivelesDelJuego.Count; i++)
                {
                    //Todas las vidas estan Activas
                    NivelesDelJuego[i].SetActive(false);
                }
                NivelesDelJuego[Niveles].SetActive(true);
                maspuntos(45);
                //El tiempo que te puede llevar completar un Laberinto
                llevaTiempo = 25;
                break;
            case 9:
                for (int i = 0; i < NivelesDelJuego.Count; i++)
                {
                    //Todas las vidas estan Activas
                    NivelesDelJuego[i].SetActive(false);
                }
                NivelesDelJuego[Niveles].SetActive(true);
                maspuntos(50);
                //El tiempo que te puede llevar completar un Laberinto
                llevaTiempo = 25;
                break;
            case 10:
                for (int i = 0; i < NivelesDelJuego.Count; i++)
                {
                    //Todas las vidas estan Activas
                    NivelesDelJuego[i].SetActive(false);
                }
                NivelesDelJuego[Niveles].SetActive(true);
                maspuntos(55);
                //El tiempo que te puede llevar completar un Laberinto
                llevaTiempo = 25;
                break;
            case 11:
                for (int i = 0; i < NivelesDelJuego.Count; i++)
                {
                    //Todas las vidas estan Activas
                    NivelesDelJuego[i].SetActive(false);
                }
                NivelesDelJuego[Niveles].SetActive(true);
                maspuntos(60);
                //El tiempo que te puede llevar completar un Laberinto
                llevaTiempo = 30;
                break;
            case 12:
                for (int i = 0; i < NivelesDelJuego.Count; i++)
                {
                    //Todas las vidas estan Activas
                    NivelesDelJuego[i].SetActive(false);
                }
                NivelesDelJuego[Niveles].SetActive(true);
                maspuntos(65);
                //El tiempo que te puede llevar completar un Laberinto
                llevaTiempo = 30;
                break;
            case 13:
                for (int i = 0; i < NivelesDelJuego.Count; i++)
                {
                    //Todas las vidas estan Activas
                    NivelesDelJuego[i].SetActive(false);
                }
                NivelesDelJuego[Niveles].SetActive(true);
                maspuntos(70);
                //El tiempo que te puede llevar completar un Laberinto
                llevaTiempo = 30;
                break;
            case 14:
                for (int i = 0; i < NivelesDelJuego.Count; i++)
                {
                    //Todas las vidas estan Activas
                    NivelesDelJuego[i].SetActive(false);
                }
                NivelesDelJuego[Niveles].SetActive(true);
                maspuntos(75);
                //El tiempo que te puede llevar completar un Laberinto
                llevaTiempo = 35;
                break;
            case 15:
                for (int i = 0; i < NivelesDelJuego.Count; i++)
                {
                    //Todas las vidas estan Activas
                    NivelesDelJuego[i].SetActive(false);
                }
                NivelesDelJuego[Niveles].SetActive(true);
                maspuntos(80);
                //El tiempo que te puede llevar completar un Laberinto
                llevaTiempo = 30;
                break;
            case 16:
                for (int i = 0; i < NivelesDelJuego.Count; i++)
                {
                    //Todas las vidas estan Activas
                    NivelesDelJuego[i].SetActive(false);
                }
                NivelesDelJuego[Niveles].SetActive(true);
                maspuntos(85);
                //El tiempo que te puede llevar completar un Laberinto
                llevaTiempo = 30;
                break;
            case 17:
                //Todos los Niveles fueron Superados 
                maspuntos(90);
                CancelInvoke("menostiempo");
                MFondo.Stop();
                //Deplecado
                //Application.LoadLevel ("Ganar");
                SceneManager.LoadScene("Escenas/Ganar");
                break;
            default:
                break;
        }
        // Este es un breve estudio de un switch
        // pero tambien se pude acortar mucho mas esta funcion sumando los puntos con una variable privada y con un else if
        // en donde si Niveles es mayor igual a 17 entonces el else if entra a la escena de ganar y mientras sea menor el proceso se va
        // repitiendo sumando puntos con esa variable privada aqui dentro.
        
    }
    public void MusicaDeFondo()
    {
        MFondo.Play();
    }
    public void Correcto()
    {
        Verdadero.Play();
    }
    public void Incorrecto()
    {
        Falso.Play();
    }
}