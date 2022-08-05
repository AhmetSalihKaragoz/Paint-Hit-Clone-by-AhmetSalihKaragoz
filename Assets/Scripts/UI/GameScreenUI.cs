using System;
using System.Collections;
using Ball;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

namespace UI
{
    public class GameScreenUI : MonoBehaviour
    {

        public TextMeshProUGUI slowMotionText;
        
        [SerializeField] private Canvas pauseScreen;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button slowMotionButton;
        
        
        private void Start()
        {
            pauseScreen.enabled = false;
            slowMotionText.text = LevelManager.Instance.slowMotionCount.ToString();
        }
        
        public void SlowMotion()
        {
            StartCoroutine(SlowMotionCoroutine());
        }
        public void PauseGame()
        {
            pauseScreen.enabled = true;
            pauseButton.enabled = false;
            Time.timeScale = 0f;
        }
        public void ResumeGame()
        {
            pauseScreen.enabled = false;
            pauseButton.enabled = true;
            Time.timeScale = 1f;
        }

        private IEnumerator SlowMotionCoroutine()
        {
            Time.timeScale = 0.5f;
            UpdateSlowMotionCount();
            yield return new WaitForSeconds(2f);
            slowMotionButton.enabled = false;
            Time.timeScale = 1f;
            slowMotionButton.enabled = true;
        }

        private void UpdateSlowMotionCount()
        {
            LevelManager.Instance.slowMotionCount--;
            slowMotionText.text = LevelManager.Instance.slowMotionCount.ToString();
        }
        
    }
    
}
