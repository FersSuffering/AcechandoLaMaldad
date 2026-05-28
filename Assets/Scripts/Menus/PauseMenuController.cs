using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{

    public AudioSource soundEffectsSource; 
    public AudioClip selectSound;

    public AudioSource musicSource;      
    public AudioClip pauseMusic;          


    void Start()
    {

        if (musicSource != null && pauseMusic != null)
        {
            musicSource.clip = pauseMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void ResumeGame()
    {
        PlaySelectSound();

        GameManager.instance.PauseUnpause();

        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    public void LoadMainMenu()
    {
        PlaySelectSound();

        SceneManager.LoadScene("StartMenu");

        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    public void QuitGame()
    {
        PlaySelectSound();

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    void PlaySelectSound()
    {
        if (soundEffectsSource != null && selectSound != null)
        {
            soundEffectsSource.PlayOneShot(selectSound);
        }
    }
}
