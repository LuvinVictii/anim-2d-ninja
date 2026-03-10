using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        input = new PlayerInputActions();
        input.Enable();
    }

    PlayerInputActions input;

    void Update()
    {
        if (input.UI.Quit.WasPressedThisFrame())
        {
            Application.Quit();
        }
        if (input.UI.Restart.WasPressedThisFrame())
        {
            Debug.Log("Restarting Scene...");
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
