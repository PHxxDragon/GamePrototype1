using TMPro;
using UnityEngine;

namespace UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
    
        private int _score;

        public void SetScore(int score)
        {
            _score = score;
            scoreText.text = "Score: " + score;
        }

        public void AddScore(int score)
        {
            _score += score;
            scoreText.text = "Score: " + _score;
        }
    }
}
