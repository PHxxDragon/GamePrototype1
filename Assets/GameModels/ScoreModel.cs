using System;
using UnityEngine;

namespace GameModels
{
    public class ScoreModel: MonoBehaviour
    {
        public event Action<int, int> OnScoreChanged;

        private int _score;
        
        public int Score
        {
            get => _score;
            set
            {
                OnScoreChanged?.Invoke(_score, value);
                _score = value;
            }
        }

        public void AddScore(int score)
        {
            Score += score;
        }

        private void OnDestroy()
        {
            OnScoreChanged = null;
        }
    }
}
