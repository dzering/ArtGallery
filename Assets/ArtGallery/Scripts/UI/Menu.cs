using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ArtGallery.Scripts.UI
{
    public class Menu : MonoBehaviour
    {
        private const string SCENE_NAME = "Game";
        [SerializeField] private Button _play;
        [SerializeField] private LoadProgressScreen _loadProgressScreen;

        public void Awake()
        {
            _loadProgressScreen.SetActive(false);
            _play.onClick.AddListener(Play);
        }

        private void Start() => 
            Screen.orientation = ScreenOrientation.Portrait;

        private void Play() => 
            StartCoroutine(LoadAsynchronously(SCENE_NAME));

        private IEnumerator LoadAsynchronously(string sceneName)
        {
            _loadProgressScreen.SetActive(true);
            AsyncOperation operation = SceneManager.LoadSceneAsync(SCENE_NAME);

            while (!operation.isDone)
            {
                float value = Mathf.Clamp01(operation.progress / 0.9f);
                _loadProgressScreen.ChangeProgress(value);
                Debug.Log(value);
                yield return null;
            }
        }

        private void OnDestroy() => 
            _play.onClick.RemoveListener(Play);
    }
}
