using System;
using UnityEngine;
using UnityEngine.UI;

namespace ArtGallery.Scripts.Logic
{
    [RequireComponent(typeof(Image), 
        typeof(Button), typeof(RectTransform))]
    public class ViewItem : MonoBehaviour
    {
        private Action<Sprite> OnButtonOpen;

        private Image _image;
        private Button _openImageButton;
        private Button _closeImage;
        public RectTransform RectTransform;

        public string Name;
        public bool IsVisible;


        public void Construct(Sprite sprite , Action<Sprite> openImage, Action closeImage)
        {
            Init();
            OnButtonOpen += openImage;
            
            _image.sprite = sprite;
            _openImageButton.onClick.AddListener(OpenImage);
        }
        private void Init()
        {
            _image = GetComponent<Image>();
            _openImageButton = GetComponent<Button>();
            RectTransform = GetComponent<RectTransform>();

        }
        private void OpenImage() =>
            OnButtonOpen?.Invoke(_image.sprite);
    }
}