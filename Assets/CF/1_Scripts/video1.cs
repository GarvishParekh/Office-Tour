using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nfynt;
public class video1 : MonoBehaviour
{
    public string videoName;
    // Start is called before the first frame update
    void Start()
    {
        PlayVideo();
    }

     public void PlayVideo()
    {
        var videoPlayer1 = GetComponent<NVideoPlayer>();

        /*if(videoPlayer1)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath + "/"+videoName);
            videoPlayer1.Config.VideoSrcPath = videoPath;


          


            videoPlayer1.Play();
        }*/
    }
}
