using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class IntroContinue : MonoBehaviour
{
    VideoPlayer video;
    public LoadingScreen load;
    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;


    }


    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        load.LoadScene(3);//the scene that you want to load after the video has ended.
    }
}
