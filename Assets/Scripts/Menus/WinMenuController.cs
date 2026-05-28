using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenuController : MonoBehaviour
{
    public Button winRestartButton;
    public Button winBackToMenuButton;
    public Button winQuitButton;

    public AudioSource winSoundEffectsSource;
    public AudioClip winSelectSound;

    public AudioSource winMusicSource;
    public AudioClip winMusicClip;

    public Canvas winMenuCanvas;

    void Start()
    {
        winRestartButton.onClick.AddListener(OnWinRestart);
        winBackToMenuButton.onClick.AddListener(OnWinBackToMenu);
        winQuitButton.onClick.AddListener(OnWinQuit);

        if (winMusicSource != null && winMusicClip != null)
        {
            winMusicSource.clip = winMusicClip;
            winMusicSource.loop = true;
            winMusicSource.Play();
        }

        winMenuCanvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void OnWinRestart()
    {
        PlayWinSelectSound();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level");

        if (winMusicSource != null && winMusicSource.isPlaying)
            winMusicSource.Stop();
    }

    void OnWinBackToMenu()
    {
        PlayWinSelectSound();
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");

        if (winMusicSource != null && winMusicSource.isPlaying)
            winMusicSource.Stop();
    }

    void OnWinQuit()
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
