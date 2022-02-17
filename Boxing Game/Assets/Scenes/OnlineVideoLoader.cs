using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class OnlineVideoLoader : MonoBehaviour
{
	
	public VideoPlayer videoPlayer;
	public string videoUrl = "yourvideourl";
	
    public AudioSource audioSource;
    // Start is called before the first frame update
    /*void Start()
    {
		videoPlayer.url = videoUrl;
		videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
		videoPlayer.EnableAudioTrack (0, true);
		videoPlayer.Prepare ();
    }*/

    void Start()
    {
        videoPlayer.targetTexture.Release();
    }
    public void play()
    {
    
		videoPlayer.url = videoUrl;
		videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);
		videoPlayer.Prepare ();
        videoPlayer.Play();
    }
    public void stop()
    {
        
        videoPlayer.targetTexture.Release();
        videoPlayer.Stop();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}