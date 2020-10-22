using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Nota2View : MonoBehaviour
{

    public Camera camera;
    public VideoPlayer videoPlayer;

    void Awake()
    {
        camera = Camera.main;
        videoPlayer = GetComponent<VideoPlayer>();
    }

    void OnTriggerEnter2D()
    {
        videoPlayer.Play();
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
