using System;
using UnityEngine;
using UnityEngine.UI;

namespace BDSM
{
    public class TargetLock : MonoBehaviour
    {
        [Header("Links")]
        public Transform targetObject;

        private bool _isLocked;
        private float _targetDistance = 0.05f;
        private Vector3 _targetPosition;
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _targetPosition = transform.position;
            SetTargetDistance(_targetDistance);
            Unlock();
        }

        public void Lock()
        {
            _isLocked = true;
            _meshRenderer.enabled = true;
        }

        public void Unlock()
        {
            _isLocked = false;
            _meshRenderer.enabled = false;
        }

        public bool IsLocked => _isLocked;

        public Vector3 GetTarget() => _targetPosition;

        public void SetTargetPosition(Vector3 targetPosition)
        {
            _targetPosition = transform.position = targetPosition;
        }

        public void SetTargetDistance(float value)
        {
            // Set scale to have radius equal value
            transform.localScale = new Vector3(value * 2, value * 2, value * 2);
            _targetDistance = value;
        }

        public bool IsWithinDistance() => Vector3.Distance(targetObject.position, _targetPosition) < _targetDistance;

        private void Update()
        {
            if (IsWithinDistance()) _meshRenderer.material = Game.Instance.okMaterial;
            else _meshRenderer.material = Game.Instance.errorMaterial;

            _targetPosition = transform.position;
        }

        public float GetTargetDistance() => _targetDistance;
        public float GetDistance() => Vector3.Distance(targetObject.position, _targetPosition);

        public void SetActive(bool v)
        {
            if (v && !_isLocked) Lock();
            else if (_isLocked) Unlock();
        }
    }
}