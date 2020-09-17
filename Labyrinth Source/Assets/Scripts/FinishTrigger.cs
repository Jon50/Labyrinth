using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

namespace Labyrinth
{
    public class FinishTrigger : MonoBehaviour
    {
        [SerializeField] private RawImage _fadeImage;
        [SerializeField] private FirstPersonController _player;
        [SerializeField] private SceneLoader _sceneLoader;

        private void OnTriggerEnter()
        {
            StartCoroutine(FadeAndLoad());
        }

        private IEnumerator FadeAndLoad()
        {
            while (_fadeImage.color.a < 1)
            {
                _fadeImage.color = new Color(0, 0, 0, _fadeImage.color.a + Time.deltaTime);
                yield return null;
            }

            _sceneLoader.MainMenu();
        }
    }
}