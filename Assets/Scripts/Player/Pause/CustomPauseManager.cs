using System;
using System.Collections.Generic;
using Player.Pause.Interfaces;
using UnityEngine;

namespace Player.Pause
{
    public class CustomPauseManager : MonoBehaviour, ICustomPauseBehavior, IPauseHandler
    {
        private List<ICustomPauseBehavior> _pausedBehaviorObjects;
        private bool _isGamePaused = false;

        public CustomPauseManager()
        {
            _pausedBehaviorObjects = new List<ICustomPauseBehavior>();
        }

        public void AddPausedBehaviorObject(ICustomPauseBehavior newBehaviorObject)
        {
            _pausedBehaviorObjects.Add(newBehaviorObject);
        }


        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.A))
            {
                ChangePauseState();
            }
        }

        public void ChangePauseState()
        {
            _isGamePaused = !_isGamePaused;
            SetPaused(_isGamePaused);
        }

        public void SetPaused(bool isPaused)
        {
            foreach (var pauseHandler in _pausedBehaviorObjects)
            {
                pauseHandler.SetPaused(_isGamePaused);
            }
        }
    }
}