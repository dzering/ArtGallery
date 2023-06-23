using UnityEngine;
using UnityEngine.SceneManagement;

namespace ArtGallery.Scripts
{
    public class SceneChangeButton : ButtonBase
    {
        [SerializeField] private string _nameScene;
        protected override void ClickButton()
        {
            SceneManager.LoadScene(_nameScene);
        }
    }
}