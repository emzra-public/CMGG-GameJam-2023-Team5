using UnityEngine;

public class SomeScript : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Instance.OnGameStateChanged += HandleGameStateChanged;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameStateChanged -= HandleGameStateChanged;
    }

    private void HandleGameStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.MainMenu:
                // Handle main menu state
                break;
            case GameState.InGame:
                // Handle in-game state
                break;
            case GameState.Paused:
                // Handle paused state
                break;
            case GameState.GameOver:
                // Handle game over state
                break;
        }
    }
}