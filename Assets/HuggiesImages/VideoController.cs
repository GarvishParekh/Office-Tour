using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {

	public VideoPlayer videoPlayer;

	public void PlayVideo()
	{
		videoPlayer.Play ();
	}
}
