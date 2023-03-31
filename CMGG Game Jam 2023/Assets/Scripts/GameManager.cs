using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    //MainMenu,
    DarkScene,
    Paused,
    GameOver,
    Cutscene1,
    LightScene
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private Vector3 playerPosition;

/*    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
*/
    private void Awake()
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
    }

    public void StartGame()
    {
        
    }

    public void PauseGame()
    {
/*        if (CurrentState == GameState.DarkScene)
        {
            CurrentState = GameState.Paused;
        }
        else if (CurrentState == GameState.Paused)
        {
            CurrentState = GameState.DarkScene;
        }*/
    }

    public void GameOver()
    {
        
    }

    /*    public void ReturnToMainMenu()
        {
            CurrentState = GameState.MainMenu;
        }*/


}

