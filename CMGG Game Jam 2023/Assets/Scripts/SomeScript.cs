using UnityEngine;
using UnityEngine.SceneManagement;

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
        Debug.Log($"GameState changed to {newState}");
        switch (newState)
        {
/*            case GameState.MainMenu:
                // Handle main state
                break;*/
            case GameState.DarkScene:
                SceneManager.LoadScene("DarkScene");
                break;
            case GameState.Paused:
                // Handle paused state
                break;
            case GameState.GameOver:
                // Handle game over state
                break;
            case GameState.Cutscene1:
                SceneManager.LoadScene("Cutscene1");
                break;
            case GameState.LightScene:
                break;
        }
    }
}