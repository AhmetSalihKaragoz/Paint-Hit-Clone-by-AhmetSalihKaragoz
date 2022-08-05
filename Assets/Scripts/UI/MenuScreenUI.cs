using System;
using Managers;
using UnityEngine;
using TMPro;

namespace UI
{
    public class MenuScreenUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI currentLevelText;

        private void Start()
        {
            UpdateMenuCurrentLevelText();
        }
        public void LoadCurrentLevel()
        {
            UpdateMenuCurrentLevelText();
            LevelManager.Instance.LoadCurrentLevel();
        }
        private void UpdateMenuCurrentLevelText()
        {
            currentLevelText.text = UIManager.Instance.currentLevelText.text;
        }
        
    }
}
