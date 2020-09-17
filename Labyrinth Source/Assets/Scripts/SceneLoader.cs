using UnityEngine;
using UnityEngine.SceneManagement;

namespace Labyrinth
{
    [CreateAssetMenu(menuName = "SceneLoader")]
    public class SceneLoader : ScriptableObject
    {
        public void StartGame() => SceneManager.LoadScene((int)Level.Game);

        public void MainMenu() => SceneManager.LoadScene((int)Level.MainMenu);

        public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        public void QuitGame() => Application.Quit();
    }
}