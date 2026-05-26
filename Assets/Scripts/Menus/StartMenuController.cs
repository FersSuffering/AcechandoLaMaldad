using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    public AudioSource soundEffectsSource;   
    public AudioClip selectSound;           

    public AudioSource musicSource;          
    public AudioClip backgroundMusic;       

    void Start()
    {
        startButton.onClick.AddListener(() => {
            PlaySelectSound();
            StartGame();
        });

        quitButton.onClick.AddListener(() => {
            PlaySelectSound();
            QuitGame();
        });

        if (musicSource != null && backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene("Level");
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
