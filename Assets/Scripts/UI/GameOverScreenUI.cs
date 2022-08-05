using System;
using Managers;
using UnityEngine;

namespace UI
{
    public class GameOverScreenUI : MonoBehaviour
    {
        public void RestartLevel()
        {
            LevelManager.Instance.LoadCurrentLevel();
        }
        public void LoadMenuScreen()
        {
            UIManager.Instance.LoadMenuScreen();
        }
        public void ResumeLevel()
        {
            UIManager.Instance.LoadGameScreen();
        }

    }
}
