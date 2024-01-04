using System;
using UnityEngine;
using UnityEngine.UI;

namespace BDSM
{
    public class Blindfold : MonoBehaviour
    {
        private Image _blindfoldImage;
        private Color _targetColor = Color.black;
        private Color _transparent = new Color(0, 0, 0, 0);
        private bool _active = false;

        public bool IsActive => _active;

        private void Awake()
        {
            _blindfoldImage = GetComponent<Image>();
        }

        public void SetColor(Color rgba)
        {            
            _targetColor = rgba;
            if (_active) _blindfoldImage.color = rgba;
        }

        public void Activate()
        {
            _active = true;
            _blindfoldImage.color = _targetColor;
        }

        public void Deactivate()
        {
            _active = false;
            _blindfoldImage.color = _transparent;
        }

        public Color GetColor() => _targetColor;
        public Color GetCurrentColor() => _blindfoldImage.color;

        internal void SetActive(bool v)
        {
            if (v) Activate();
            else Deactivate();
        }
    }
}