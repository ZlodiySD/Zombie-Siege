using System;
using UnityEngine;

namespace Didenko.UI
{
    public class UIFollow : MonoBehaviour
    {
        [Header("Rotation Clamp")]
        public float MinXAngle;
        public float MaxXAngle;

        public Canvas Canvas;

        private Transform _playerTransform;
        private Transform _selfTransform;

        private Camera _mainCamera;

        public void Init(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }

        private void Start()
        {
            _selfTransform = gameObject.transform;
            _mainCamera = Camera.main;

            RotateCanvas();
        }

        private void Update()
        {
            PlayerFollow();
            LookAtCamera();

            LimitRotation();
        }

        private void RotateCanvas()
        {
            Vector3 rotation = Canvas.transform.rotation.eulerAngles;
            rotation.y = 25;

            Canvas.transform.rotation = Quaternion.Euler(rotation);
        }

        private void PlayerFollow()
        {
            _selfTransform.position = _playerTransform.position;
        }

        private void LookAtCamera()
        { 
            Quaternion rotation = _mainCamera.transform.rotation;
            _selfTransform.LookAt(_selfTransform.position + rotation * Vector3.forward, rotation * Vector3.up);
        }

        private void LimitRotation()
        {
            Vector3 rotationEulerAngles = _selfTransform.rotation.eulerAngles;
            rotationEulerAngles.x = Math.Clamp(rotationEulerAngles.x, MinXAngle, MaxXAngle);
        
            _selfTransform.rotation = Quaternion.Euler(rotationEulerAngles);
        }
    }
}