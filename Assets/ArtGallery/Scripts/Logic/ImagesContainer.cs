using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ArtGallery.Scripts.Logic
{
    public class ImagesContainer : MonoBehaviour, IImageContainer
    {
        public event Action OnScroll;

        public RectTransform Content;
        public RectTransform ViewPort;
        public GridLayoutGroup GridLayoutGroup;
        
        [SerializeField] public GameObject _itemPrefab;
        [SerializeField] private ImageViewer _imageViewer;
        
        [HideInInspector] public List<ViewItem> Items = new List<ViewItem>();
        [HideInInspector] public List<ViewItem> ItemsFilled = new List<ViewItem>();

        private ScrollRect _scrollRect;

        private void Awake()
        {
            _scrollRect = GetComponent<ScrollRect>();
            _scrollRect.onValueChanged.AddListener(Scroll);
        }

        public ViewItem LastItem => Items[^1];

        public void CreateEmptyItem()
        {
            GameObject item = Instantiate(_itemPrefab, Content);
            ViewItem viewItem = item.GetComponent<ViewItem>();
            Items.Add(viewItem);
        }

        public void AddItem(Sprite sprite)
        {
            ViewItem item = Items[ItemsFilled.Count];
            item.Construct(sprite, _imageViewer.OpenImage, _imageViewer.Close);
            ItemsFilled.Add(item);
        }

        private void Scroll(Vector2 value) =>
            OnScroll?.Invoke();
    }
}