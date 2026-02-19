using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // 🎮 Oyun sahnesi index'i (Build Settings'ten 3 olmalı)
    [SerializeField] private int gameSceneIndex = 3;

    private void Load(int index)
    {
        // Pause menü açıksa oyun durmuş olabilir
        Time.timeScale = 1f;

        // Cursor sahne geçişinde sorun çıkarmasın
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene(index);
    }

    // ✅ Menüdeki butonlar
    public void NewGame()
    {
        Load(gameSceneIndex); // 🎮 OYUN
    }

    public void ContinueGame()
    {
        Load(gameSceneIndex); // 🎮 OYUN
    }

    public void OpenSettings()
    {
        Load(1); // ayarlar
    }

    public void BackToMenu()
    {
        Load(2); // menu
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
