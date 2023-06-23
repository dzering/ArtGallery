using System;
using UnityEngine;
using UnityEngine.UI;

namespace ArtGallery.Scripts.Logic
{
    public class ImageViewer : MonoBehaviour
    {
        [SerializeField] private Button _close;
        [SerializeField] private Image _image;
        [SerializeField] private Canvas _canvas;
        private DeviceOrientation _orientation;
        private RectTransform _rectButton;

        private void Update()
        {
            DeviceOriented();
        }

        private void DeviceOriented()
        {
            if (_orientation == Input.deviceOrientation)
                return;
            _orientation = Input.deviceOrientation;
            OrientationWasChanged();
            AdjustButtonClose(_orientation);
        }

        private void OrientationWasChanged() =>
            AdjustImageSize();

        private void Awake()
        {
            _rectButton = _close.GetComponent<RectTransform>();
            _orientation = Input.deviceOrientation;
            gameObject.SetActive(false);
            _close.onClick.AddListener(Close);
        }

        public void OpenImage(Sprite sprite)
        {
            gameObject.SetActive(true);
            _image.sprite = sprite;
            AdjustImageSize();
            Screen.orientation = ScreenOrientation.AutoRotation;
        }

        public void Close()
        {
            gameObject.SetActive(false);
            _image.sprite = null;
            Screen.orientation = ScreenOrientation.Portrait;
        }

        private void AdjustButtonClose(DeviceOrientation orientation)
        {
            float height = _rectButton.rect.height;
            float width = _rectButton.rect.width;

            if (_orientation == DeviceOrientation.Portrait || _orientation == DeviceOrientation.PortraitUpsideDown)
                _rectButton.anchoredPosition = new Vector2(width, height / 2);
            if (_orientation == DeviceOrientation.LandscapeLeft || _orientation == DeviceOrientation.LandscapeRight)
                _rectButton.anchoredPosition = new Vector2( -width, -height / 2);
        }

        private void AdjustImageSize()
        {
            if (_image.sprite != null)
            {
                float screenAspect = (float)Screen.width / Screen.height;
                float spriteAspect = (float)_image.sprite.texture.width / _image.sprite.texture.height;

                if (spriteAspect > screenAspect)
                {
                    float k = _image.sprite.texture.width * _canvas.scaleFactor / Screen.width;

                    _image.rectTransform.sizeDelta = new Vector2(_image.sprite.texture.width / k
                        , _image.sprite.texture.height / k);
                }
                else
                {
                    float k = _image.sprite.texture.height * _canvas.scaleFactor / Screen.height;

                    _image.rectTransform.sizeDelta = new Vector2(_image.sprite.texture.width / k
                        , _image.sprite.texture.height / k);
                }
            }
        }
    }
}