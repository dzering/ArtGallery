using System.Collections;
using ArtGallery.Scripts.Logic;
using ArtGallery.Scripts.Services;
using UnityEngine;

namespace ArtGallery.Scripts
{
    public class Game : MonoBehaviour
    {
        public ImagesContainer _imagesContainer;
        private VisibilityChecker _visibilityChecker;
        public PathHolder PathHolder;
        private ImageService _imageService;
        private void Start()
        {
            _imageService = new ImageService(_imagesContainer, new WebRequest());
            _visibilityChecker = new VisibilityChecker();

            _imagesContainer.OnScroll += Scroll;

            StartCoroutine(StartGame());
        }

        private IEnumerator StartGame()
        {
            DownloadImages();
            while (!CheckVisible())
            {
                DownloadImages();
                yield return null;
            }
        }

        private void OnDestroy() => 
            _imagesContainer.OnScroll -= Scroll;

        private void Scroll()
        {
            if(PathHolder.Count <= _imagesContainer.Items.Count)
                return;
            
            if(CheckVisible())
                return;
            
            DownloadImages();
        }

        private bool CheckVisible() =>
            _visibilityChecker.CheckVisible(_imagesContainer.LastItem.RectTransform, _imagesContainer.Content, 
                _imagesContainer.ViewPort);

        private void DownloadImages()
        {
            _imagesContainer.CreateEmptyItem();
            _imageService.Load(PathHolder.GetNextPath());
        }
    }
}

