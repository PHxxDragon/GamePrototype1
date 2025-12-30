using GameModels;
using Sisus.Init;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameUI : MonoBehaviour<ScoreModel>
    {
        [SerializeField] private TMP_Text scoreText;
    
        private ScoreModel _scoreModel;
        
        protected override void Init(ScoreModel scoreModel)
        {
            _scoreModel = scoreModel;
            _scoreModel.OnScoreChanged += OnScoreChanged;
        }

        private void OnScoreChanged(int oldScore, int newScore)
        {
            scoreText.text = "Score: " + newScore;
        }

        private void OnDestroy()
        {
            _scoreModel.OnScoreChanged -= OnScoreChanged;
        }
    }
}
