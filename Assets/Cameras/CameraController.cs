using System;
using InputActions;
using Sisus.Init;
using UnityEngine;

namespace Cameras
{
    public class CameraController : MonoBehaviour<InputReader>
    {
        [SerializeField] private new Camera camera; 
        
        private InputReader _inputReader;

        protected override void Init(InputReader inputReader)
        {
            _inputReader = inputReader;
            _inputReader.OnReset += InputReaderOnOnReset; 
        }

        private void InputReaderOnOnReset()
        {
            camera.transform.position = Vector3.zero;
            camera.orthographicSize = 10f;
        }

        private void OnDestroy()
        {
            _inputReader.OnReset -= InputReaderOnOnReset;
        }

        private void Update()
        {
            camera.transform.position += (Vector3) _inputReader.MoveVector * (Time.deltaTime * 5f);
            camera.orthographicSize *= (1 + _inputReader.ZoomValue * Time.deltaTime);
        }
    }
}
