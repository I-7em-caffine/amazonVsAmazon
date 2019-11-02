using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToStartMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("Escape")) { SceneManager.LoadScene(0); }
    }
}
