using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class VideoSplashManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName = "IntroScene"; 

    void Start()
    {
        if (videoPlayer == null)
            videoPlayer = GetComponent<VideoPlayer>();

        
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void Update()
    {
        
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            LoadScene();
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        LoadScene();
    }

    void LoadScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}