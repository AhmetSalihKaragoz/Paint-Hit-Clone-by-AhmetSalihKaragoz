using System.Collections;
using System.Collections.Generic;
using Circle;
using Managers;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        
        [Header("Canvases")]
        [SerializeField] private Canvas gameScreen;
        [SerializeField] private Canvas menuScreen;
        [SerializeField] private Canvas levelTransitionScreen;
        [SerializeField] private Canvas levelCompeleteScreen;
        [SerializeField] private Canvas gameOverScreen;

        public TextMeshProUGUI currentLevelText;
        [Header("LevelTransition")]
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI targetCountText;
        
        [Header("REFERENCES")]
        [SerializeField] private List<CirclePiece> pieces;
        [SerializeField] private GameObject circle;
        [SerializeField] private GameObject ball;
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
        private void Start()
        {
            levelCompeleteScreen.enabled = false;
            UpdateCurrentLevelText();
            LoadGameScreen();
        }
        public void LoadGameOverScreen()
        {
            SetGameObjectsOff();
            gameOverScreen.enabled = true;
            gameScreen.enabled = false;
            CirclePieceBoolReset();
        }
        public void LoadGameScreen()
        {
            gameScreen.enabled = false;
            gameOverScreen.enabled = false;
            menuScreen.enabled = false;
            UpdateLevelTransitionText();
            levelTransitionScreen.enabled = true;
            StartCoroutine(LevelTransition());
        }
        public void LoadMenuScreen()
        {
            gameOverScreen.enabled = false;
            gameScreen.enabled = false;
            menuScreen.enabled = true;
        }

        public void LevelCompleteScreen()
        {
            levelCompeleteScreen.enabled = true;
            SetGameObjectsOff();
            gameScreen.enabled = false; 
            StartCoroutine(LevelComplete());
        }
        private  IEnumerator LevelTransition()
        {
            SetGameObjectsOff(); 
            yield return new WaitForSeconds(2f);
            levelTransitionScreen.enabled = false; 
            gameScreen.enabled = true;
            SetGameObjectsOn();
 
        }

        private IEnumerator LevelComplete()
        {
            yield return new WaitForSeconds(1);
            levelCompeleteScreen.enabled = false;
            LoadGameScreen();
        }
        private void CirclePieceBoolReset()
        {
            foreach (var piece in pieces)
            {
                piece.isColored = false;
            }
        }

        private void SetGameObjectsOn()
        {
            circle.SetActive(true);
            ball.SetActive(true);
        }

        private void SetGameObjectsOff()
        {
            circle.SetActive(false);
            ball.SetActive(false);
        }

        public void UpdateCurrentLevelText()
        {
            currentLevelText.text = "Level " + LevelManager.Instance.currentLevel;
        }

        private void UpdateLevelTransitionText()
        {
            levelText.text = currentLevelText.text;
            targetCountText.text = "Target " + ColorManager.Instance.targetPieceColored;
        }
    }
}