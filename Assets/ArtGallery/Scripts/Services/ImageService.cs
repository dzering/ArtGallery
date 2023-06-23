using ArtGallery.Scripts.Logic;
using UnityEngine;

namespace ArtGallery.Scripts.Services
{
    public class ImageService
    {
        private readonly IImageContainer _imageContainer;
        private readonly IWebRequest _webRequest;
        public ImageService(IImageContainer imageContainer, IWebRequest webRequest)
        {
            _imageContainer = imageContainer;
            _webRequest = webRequest;
        }
        
        public void Load(string url) => 
            _webRequest.GetTexture(url, OnSuccess);

        private void OnSuccess(Texture2D texture2D)
        {
            Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), 
                new Vector2(0.5f, 0.5f), 100);
            _imageContainer.AddItem(sprite);
        }
    }
}