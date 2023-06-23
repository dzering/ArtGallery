using UnityEngine;
using UnityEngine.UI;

namespace ArtGallery.Scripts
{
    public abstract class ButtonBase : MonoBehaviour
    {
        private void Awake()
        {
            Button quitButton = GetComponent<Button>();
            quitButton.onClick.AddListener(ClickButton);
        }

        protected abstract void ClickButton();
    }
}