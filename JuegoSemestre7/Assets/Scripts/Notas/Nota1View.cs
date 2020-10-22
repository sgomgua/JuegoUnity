using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;


public class Nota1View : MonoBehaviour
{
    public Camera camera;
    public VideoPlayer videoPlayer;
    public GameObject player;
    public GameObject CM_Vcam1;
    public Text puntaje;
    public int contador  = 0;
    public 
    void Awake() 
    {
        camera = Camera.main;
        videoPlayer = GetComponent<VideoPlayer>();
        player = GameObject.Find("Player");
        CM_Vcam1 = GameObject.Find("CM vcam1");
    }

    void OnTriggerEnter2D() 
    {
        videoPlayer.Play();
        if (Input.GetKey(KeyCode.Escape))
        {
            videoPlayer.Stop();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            videoPlayer.Stop();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            videoPlayer.Stop();
        }
        System.Random random = new System.Random();
        AudioSource audio  = CM_Vcam1.GetComponent<AudioSource>();
        audio.pitch = random.Next(-3,3);
        if (!player.GetComponent<PlayerMovement>().notasCapturadas.Contains(gameObject.tag))
        {
            contador += player.GetComponent<PlayerMovement>().notasCapturadas.Count + 1;
            puntaje.text = "Notas Encontradas: " + contador;
        }

    }

    void OnTriggerExit2D() 
    {
        videoPlayer.Stop();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
