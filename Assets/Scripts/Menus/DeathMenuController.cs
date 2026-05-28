using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class DeathMenuController : MonoBehaviour
{
    public Button restartButton;
    public Button backToMenuButton;
    public Button quitButton;

    public Canvas gameOverCanvas;    
    public Canvas deathCanvas;       

    public AudioSource soundEffectsSource;
    public AudioClip selectSound;

    public AudioSource musicSource;
    public AudioClip deathMusic;

    public float delayBeforeMenu = 3f; 

    void Start()
    {
        if (gameOverCanvas != null)
            gameOverCanvas.gameObject.SetActive(true);

        if (deathCanvas != null)
            deathCanvas.gameObject.SetActive(false);

        if (musicSource != null && deathMusic != null)
        {
            musicSource.clip = deathMusic;
            musicSource.loop = true;
            musicSource.Play();
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        StartCoroutine(ShowMenuAfterDelay());
        restartButton.onClick.AddListener(() => {
            PlaySelectSound();
            RestartGame();
        });

        backToMenuButton.onClick.AddListener(() => {
            PlaySelectSound();
            LoadMainMenu();
        });

        quitButton.onClick.AddListener(() => {
            PlaySelectSound();
            Invoke("QuitGame", 0.5f);
        });
    }

    IEnumerator ShowMenuAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeMenu);

        if (gameOverCanvas != null)
            gameOverCanvas.gameObject.SetActive(false);

        if (deathCanvas != null)
            deathCanvas.gameObject.SetActive(true);
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level");

        if (musicSource != null && musicSource.isPlaying)
            musicSource.Stop();
    }

    void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");

        if (musicSource != null && musicSource.isPlaying)
            musicSource.Stop();
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
            soundEffectsSource.PlayOneShot(selectSound);
    }
}
