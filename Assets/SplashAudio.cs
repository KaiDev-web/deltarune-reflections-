using UnityEngine;

public static class SplashAudio
{
   
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    private static void PlayMusicOnSplash()
    {
        AudioClip music = Resources.Load<AudioClip>("IntroMusic");

        if (music != null)
        {
            GameObject audioObj = new GameObject("SplashAudioPlayer");
            AudioSource source = audioObj.AddComponent<AudioSource>();
            source.clip = music;
            source.playOnAwake = false;
            source.Play();

            
            Object.DontDestroyOnLoad(audioObj);
        }
        else
        {
            Debug.LogWarning("Audio 'IntroMusic' non trovato nella cartella Resources!");
        }
    }
}