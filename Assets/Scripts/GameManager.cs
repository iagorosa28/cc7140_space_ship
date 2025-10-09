using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int Score = 0;
    public static int Lives = 3;

    public GUISkin layout;

    private void Awake()
    {
        Score = 0;
        Lives = 3;
    }

    public static void AddScore(int amount)
    {
        Score += amount;
        if(Score >= 500)
        {
            Parallax.movingSpeed = 1;
            Spawn.waitTime = 1.0f;
            Inimigo.movingSpeed = 2.5f;
            SceneLoader.LoadVictory();
        }
    }

    public static void LoseLife()
    {
        Lives--;
        if(Lives <= 0)
        {
            Parallax.movingSpeed = 1;
            Spawn.waitTime = 1.0f;
            Inimigo.movingSpeed = 2.5f;
            SceneLoader.LoadGameOver();
        }
    }

    void OnGUI()
    {
        if (layout) GUI.skin = layout;

        GUI.Label(new Rect(20, 20, 200, 40), "Score: " + Score);
        GUI.Label(new Rect(Screen.width - 140, 20, 120, 40), "Lives: " + Lives);
    }
}
