using System;
using Circle;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;
        
        public int currentLevel = 1;
        public int slowMotionCount = 3;
            
        [SerializeField] private CircleSpawner circleSpawner;
        [SerializeField] private GameScreenUI gameScreenUI;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        public void LoadCurrentLevel()
        {
            UIManager.Instance.LoadGameScreen();
            ColorManager.Instance.ResetColor();
            UIManager.Instance.UpdateCurrentLevelText();
            circleSpawner.CleanCircleList();
        }
        public void UpdateSlowMotionCount()
        {
            slowMotionCount++;
            gameScreenUI.slowMotionText.text = slowMotionCount.ToString();
        }
    }
}
