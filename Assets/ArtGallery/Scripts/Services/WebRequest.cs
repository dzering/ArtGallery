using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace ArtGallery.Scripts.Services
{
    public class WebRequest : IWebRequest
    {
        private class WebRequestMonoBehaviour : MonoBehaviour { }

        private WebRequestMonoBehaviour _webRequestMonoBehaviour;

        public void GetTexture(string url, Action<Texture2D> onSuccess)
        {
            Init();
            _webRequestMonoBehaviour.StartCoroutine(GetTextureCoroutine(url, onSuccess));
        }

        private void Init()
        {
            if (_webRequestMonoBehaviour == null)
            {
                GameObject gameObject = new GameObject("WebRequest");
                _webRequestMonoBehaviour = gameObject.AddComponent<WebRequestMonoBehaviour>();
            }
        }

        private IEnumerator GetTextureCoroutine(string url, Action<Texture2D> onSuccess)
        {
            UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture(url);
            using (unityWebRequest)
            {
                yield return unityWebRequest.SendWebRequest();
                
                switch (unityWebRequest.result)
                {
                    case UnityWebRequest.Result.InProgress:
                        Debug.Log("InProgress");
                        break;
                    case UnityWebRequest.Result.Success:
                        DownloadHandlerTexture handlerTexture = unityWebRequest.downloadHandler as DownloadHandlerTexture;
                        onSuccess(handlerTexture.texture);
                        break;
                    case UnityWebRequest.Result.ConnectionError:
                        Debug.Log("ConnectionError");
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        Debug.Log("ProtocolError");
                        break;
                    case UnityWebRequest.Result.DataProcessingError:
                        Debug.Log("DataProcessingError");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

    public interface IWebRequest
    {
        void GetTexture(string url, Action<Texture2D> onSuccess);
    }
}