using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void LoadGame() => SceneManager.LoadScene("Level1"); 
    public static void LoadStart() => SceneManager.LoadScene("StartScene");
    public static void LoadVictory() => SceneManager.LoadScene("Victory");
    public static void LoadGameOver() => SceneManager.LoadScene("GameOver");
}



