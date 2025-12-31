using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputActions
{
    public class InputReader : MonoBehaviour
    {
        private InputMap _inputMap;

        public Vector2 MoveVector { get; private set; }
        public float ZoomValue { get; private set; }
        public event Action OnReset; 

        private void Awake()
        {
            _inputMap = new InputMap(); 
            _inputMap.Camera.CameraReset.performed += OnCameraResetPerformed; 
        }

        private void OnCameraResetPerformed(InputAction.CallbackContext obj)
        {
            OnReset?.Invoke();
        }

        private void OnEnable()
        {
            _inputMap.Enable(); 
        }

        private void OnDisable()
        {
            _inputMap.Disable();
        }

        private void OnDestroy()
        {
            _inputMap.Camera.CameraReset.performed -= OnCameraResetPerformed;
        }

        private void Update()
        {
            MoveVector = _inputMap.Camera.CameraMove.ReadValue<Vector2>();
            ZoomValue = _inputMap.Camera.CameraZoom.ReadValue<float>(); 
        }
    }
}
