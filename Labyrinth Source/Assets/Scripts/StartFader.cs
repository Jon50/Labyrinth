using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

namespace Labyrinth
{
    public class StartFader : MonoBehaviour
    {
        [SerializeField] private RawImage _fadeImage;
        [SerializeField] private Transform _player;
        [SerializeField] private SceneLoader _sceneLoader;

        private bool _fading = false;

        private IEnumerator Start()
        {
            FirstPersonController playerController = null;
            if (_player != null)
                playerController = _player?.GetComponent<FirstPersonController>();

            _fadeImage.gameObject.SetActive(true);

            while (_fadeImage.color.a > 0)
            {
                _fadeImage.color = new Color(0, 0, 0, _fadeImage.color.a - Time.deltaTime);
                playerController.enabled = false;
                yield return null;
            }

            if (playerController != null)
                playerController.enabled = true;
        }

        public void FadeIn()
        {
            if (_fading) { return; }
            StartCoroutine(FadeInRoutine());
        }

        public IEnumerator FadeInRoutine()
        {
            _fading = true;

            while (_fadeImage.color.a < 1)
            {
                _fadeImage.color = new Color(0, 0, 0, _fadeImage.color.a + Time.deltaTime);
                yield return null;
            }

            _sceneLoader?.StartGame();
        }
    }
}