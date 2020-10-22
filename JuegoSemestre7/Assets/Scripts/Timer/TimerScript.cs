using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Threading;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using System.Timers;

public class TimerScript : MonoBehaviour
{
    [Tooltip("Tiempo iniciar en Segundos")]
    public int tiempoinicial;
    [Tooltip("Escala del Tiempo del Reloj")]
    [Range(-10.0f, 10.0f)]
    public float escalaDeTiempo = 1;
    public VideoPlayer videoPlayer;
    public Text myText;
    private float TiempoFrameConTiempoScale = 0f;
    private float tiempoMostrarEnSegundos = 0F;
    private float escalaDeTiempoPausar, escalaDeTiempoInicial;
    private bool EstaPausado = false;
    private bool gameOver = false;
    void Awake() 
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    void Start()
    {
        //Escala de Tiempo Original
        escalaDeTiempoInicial = escalaDeTiempo;


        tiempoMostrarEnSegundos = tiempoinicial;

        ActualizarReloj(tiempoinicial);
    }

    // Update is called once per frame
    void Update()
    {
        TiempoFrameConTiempoScale = Time.deltaTime * escalaDeTiempo;
        tiempoMostrarEnSegundos += TiempoFrameConTiempoScale;
        ActualizarReloj(tiempoMostrarEnSegundos);
    }
    public void ActualizarReloj(float tiempoEnSegundos)
    {
        if (!gameOver)
        {
            int minutos = 0;
            int segundos = 0;
            // int milisegundos = 0;
            string textoDelReloj;

            if (tiempoEnSegundos < 0) tiempoEnSegundos = 0;

            minutos = (int)tiempoEnSegundos / 60;
            segundos = (int)tiempoEnSegundos % 60;
            //milisegundos = (int)tiempoEnSegundos / 1000;

            textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00"); //+ ":" + milisegundos.ToString("00");
            myText.text = textoDelReloj;
            if (textoDelReloj.Equals("01:30"))
            {
                videoPlayer.Play();
                myText.text = "";
                gameOver = true;
                SceneManager.LoadScene("CanvasMenu");

            }
        }
    }
}
