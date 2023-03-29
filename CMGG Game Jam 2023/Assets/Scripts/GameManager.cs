using UnityEngine;

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
    private GameState _currentState = GameState.DarkScene;

    public void StartCutscene1()
    {
        previousState = CurrentState;
        CurrentState = GameState.Cutscene1;
    }

    public void EndCutscene1()
    {
        //Debug.Log("Current State Bf: " + CurrentState);
        CurrentState = previousState;
        Debug.Log("Current State After: " + CurrentState);
        Debug.Log("End Cutscene1 called");
    }

    public GameState CurrentState
    {
        get => _currentState;
        set
        {
            _currentState = value;
            OnGameStateChanged?.Invoke(_currentState);
        }
    }

    public delegate void GameStateChanged(GameState newState);
    public event GameStateChanged OnGameStateChanged;
    private GameState previousState;

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
        CurrentState = GameState.DarkScene;
    }

    public void PauseGame()
    {
        if (CurrentState == GameState.DarkScene)
        {
            CurrentState = GameState.Paused;
        }
        else if (CurrentState == GameState.Paused)
        {
            CurrentState = GameState.DarkScene;
        }
    }

    public void GameOver()
    {
        CurrentState = GameState.GameOver;
    }

/*    public void ReturnToMainMenu()
    {
        CurrentState = GameState.MainMenu;
    }*/

}