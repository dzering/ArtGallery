using UnityEngine;
using UnityEngine.UI;

namespace ArtGallery.Scripts.UI
{
    public class LoadProgressScreen : MonoBehaviour
    {
        [SerializeField] private Slider _progressBar;

        private void Awake() => 
            _progressBar.onValueChanged.AddListener(ChangeProgress);

        public void SetActive(bool isActive) => 
            gameObject.SetActive(isActive);

        public void ChangeProgress(float value) => 
            _progressBar.value = value;

        private void OnDestroy() => 
            _progressBar.onValueChanged.RemoveListener(ChangeProgress);
    }
}