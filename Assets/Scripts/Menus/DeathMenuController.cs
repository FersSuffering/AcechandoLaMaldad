using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenuController : MonoBehaviour
{
    public Button backToMenuButton;
    public Button quitButton;

    public AudioSource soundEffectsSource; 
    public AudioClip selectSound;

    public AudioSource musicSource;        
    public AudioClip deathMusic;          

    public Canvas deathCanvas; 

    void Start()
    {
        backToMenuButton.onClick.AddListener(() => {
            PlaySelectSound();
            LoadMainMenu();
        });

        quitButton.onClick.AddListener(() => {
            PlaySelectSound();
            Invoke("QuitGame", 0.5f);
        });

        if (musicSource != null && deathMusic != null)
        {
            musicSource.clip = deathMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");

        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    void QuitGame()
    {
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
