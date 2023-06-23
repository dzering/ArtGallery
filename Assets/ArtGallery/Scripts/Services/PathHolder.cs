using System.Collections.Generic;
using UnityEngine;

namespace ArtGallery.Scripts.Services
{
    public class PathHolder : MonoBehaviour
    {
        public int From;
        public int To;

        public int Count => (To - From+1);

        [SerializeField] private Path _path;
        private List<string> _paths = new List<string>();
        private int _currentPath;
        private void Awake()
        {
            _currentPath = -1;
            for (int i = From; i <= To; i++) 
                _paths.Add(_path.PathFile + i + _path.Format);
        }

        public string GetNextPath()
        {
            _currentPath++;
            if (_currentPath >= _paths.Count)
                return null;
            return _paths[_currentPath];
        }
    }
}