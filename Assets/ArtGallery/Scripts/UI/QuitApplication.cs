using UnityEngine;

namespace ArtGallery.Scripts
{
    public class QuitApplication : ButtonBase
    {
        protected override void ClickButton()
        {
            Application.Quit();
        }
    }
}