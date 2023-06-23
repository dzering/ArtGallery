using System;
using UnityEngine;

namespace ArtGallery.Scripts.Logic
{
    public class VisibilityChecker
    {
        public bool CheckVisible(RectTransform item, RectTransform content, RectTransform viewPortRectTransform)
        {
            var itemAnchoredPositionY = item.anchoredPosition.y - item.rect.height/2;

            bool isWithinVerticalView = Math.Abs(itemAnchoredPositionY) > content.anchoredPosition.y +
                                        viewPortRectTransform.rect.height;

            return isWithinVerticalView;
            
        }
    }
}