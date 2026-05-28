using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenuController : MonoBehaviour
{
    public AudioSource winSoundEffectsSource;
    public AudioClip winSelectSound;

    public AudioSource winMusicSource;
    public AudioClip winMusicClip;

    public AudioSource winCheerSource;
    public AudioClip winCheerClip;


    void Start()
    {

        if (winMusicSource != null && winMusicClip != null)
        {
            winMusicSource.clip = winMusicClip;
            winMusicSource.loop = true;
            winMusicSource.Play();
        }

        if (winCheerSource != null && winCheerClip != null)
        {
            winCheerSource.clip = winCheerClip;
            winCheerSource.Play();
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Restart()
    {
        PlayWinSelectSound();

        SceneManager.LoadScene("Level");

        if (winMusicSource != null && winMusicSource.isPlaying)
            winMusicSource.Stop();
    }

    public void BackToMenu()
    {
        PlayWinSelectSound();

        SceneManager.LoadScene("StartMenu");

        if (winMusicSource != null && winMusicSource.isPlaying)
            winMusicSource.Stop();
    }

    public void Quit()
    {
        PlayWinSelectSound();

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    void PlayWinSelectSound()
    {
        if (winSoundEffectsSource != null && winSelectSound != null)
            winSoundEffectsSource.PlayOneShot(winSelectSound);
    }
}
