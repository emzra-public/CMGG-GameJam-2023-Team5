using UnityEngine;

public enum GameState
{
    MainMenu,
    InGame,
    Paused,
    GameOver,
    Cutscene
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public void StartCutscene()
    {
        previousState = CurrentState;
        CurrentState = GameState.Cutscene;
    }

    public void EndCutscene()
    {
        CurrentState = previousState;
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

    private GameState _currentState = GameState.MainMenu;

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
        CurrentState = GameState.InGame;
    }

    public void PauseGame()
    {
        if (CurrentState == GameState.InGame)
        {
            CurrentState = GameState.Paused;
        }
        else if (CurrentState == GameState.Paused)
        {
            CurrentState = GameState.InGame;
        }
    }

    public void GameOver()
    {
        CurrentState = GameState.GameOver;
    }

    public void ReturnToMainMenu()
    {
        CurrentState = GameState.MainMenu;
    }

}