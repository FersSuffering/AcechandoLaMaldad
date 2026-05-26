using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public Button backToGameButton;
    public Button backToMenuButton;
    public Button quitButton;

    public AudioSource soundEffectsSource; 
    public AudioClip selectSound;

    public AudioSource musicSource;      
    public AudioClip pauseMusic;          


    void Start()
    {

        backToGameButton.onClick.AddListener(() => {
            PlaySelectSound();
            ResumeGame();
        });

        backToMenuButton.onClick.AddListener(() => {
            PlaySelectSound();
            LoadMainMenu();
        });

        quitButton.onClick.AddListener(() => {
            PlaySelectSound();
            Invoke("QuitGame", 0.5f);
        });

        if (musicSource != null && pauseMusic != null)
        {
            musicSource.clip = pauseMusic;
            musicSource.loop = true;
            musicSource.Play();
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level");

        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
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
