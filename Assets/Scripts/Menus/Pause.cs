using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPauseMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("PauseMenu");
        }
    }
}
