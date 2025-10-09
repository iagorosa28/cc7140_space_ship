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
    }

    public static void LoseLife()
    {
        Lives--;
        if(Lives <= 0)
        {
            Score = 0; Lives = 3; Spawn.waitTime = 1.0f;
        }
    }

    void OnGUI()
    {
        if (layout) GUI.skin = layout;

        GUI.Label(new Rect(20, 20, 200, 40), "Score: " + Score);
        GUI.Label(new Rect(Screen.width - 140, 20, 120, 40), "Lives: " + Lives);

        // botão de reiniciar nível
        if (GUI.Button(new Rect(Screen.width / 2 - 60, 20, 120, 40), "Restart"))
        {
            Score = 0; Lives = 3; Spawn.waitTime = 1.0f;
        }
    }
}
