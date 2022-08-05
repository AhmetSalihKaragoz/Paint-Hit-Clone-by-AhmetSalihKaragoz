using System;
using System.Collections.Generic;
using Circle;
using UI;
using UnityEngine;

namespace Managers
{
    public class ColorManager : MonoBehaviour
    {
        public static ColorManager Instance;
    
        [Header("Other")]
        public GameObject wholeCirclePrefab;
        [HideInInspector] public List<GameObject> triggeredPieceList = new List<GameObject>();
    
        [Header("Color")]
        public List<Color> colorList1 = new List<Color>();
        public Color currentColor;
        private Color _startingColor;
        private List<GameObject> _splashColorList = new List<GameObject>();

        [Header("Variables")]
        public int numOfCircleColored;
        public int targetPieceColored = 4;
        private int _numOfPieceColored;
        private int _targetCircleColored = 3;
        private int _startingTargetPieceColored;

        public AnimationClip splashAnimation;
    
        [Header("References")]
        public GameObject splashPrefab;
        [SerializeField] private CircleSpawner circleSpawner;
    
        
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
            GetStartingValue();
        }

        public Color GetCurrentColor()
        {
            currentColor = colorList1[numOfCircleColored];
            return currentColor;
        }
        public void SetSplashColor(GameObject @object)
        {
            //var instance = Instantiate(splashPrefab, new Vector3(0, 0, -1.92f), Quaternion.identity, @object.transform);
            //GetColor(instance, numOfCircleColored);
            //_splashColorList.Add(instance);
        }

        public void ClearSplash()
        {
            for (var i = 0; i < _splashColorList.Count; i++)
            {
                Destroy(_splashColorList[i]);
            }
        }

        public void SetCirclePieceColor(GameObject @object)
        {
            @object.GetComponent<Renderer>().enabled = true;
            GetColor(@object, numOfCircleColored);
            _numOfPieceColored++;
            SetWholeCircleColor(@object);
        }

        private void SetWholeCircleColor(GameObject @object)
        {
            if (_numOfPieceColored != targetPieceColored) return;
            GetColor(wholeCirclePrefab,numOfCircleColored);
            circleSpawner.SpawnCircle();
            ResetColor();
            WholeCircleProcessor(@object);
            LoadNextLevel();
        }
        public void ResetColor()
        {
            wholeCirclePrefab.GetComponent<Renderer>().material.color = _startingColor;
            ResetPieceColor();
        }

        private void ResetPieceColor()
        {
            foreach (var t in triggeredPieceList)
            {
                t.GetComponent<Renderer>().material.color = _startingColor;
                t.GetComponent<Renderer>().enabled = false;
            }
        }
        private void WholeCircleProcessor(GameObject @object)
        {
            @object.GetComponent<Renderer>().enabled = false;
            _numOfPieceColored = 0;
            numOfCircleColored++;
        }
        private void GetColor(GameObject @object, int num)
        {
            @object.GetComponent<Renderer>().material.color = GetCurrentColor();
        }

        private void LoadNextLevel()
        {
            if (numOfCircleColored != _targetCircleColored) return;
            numOfCircleColored = 0;
            targetPieceColored = _startingTargetPieceColored;
            targetPieceColored++;
            LevelManager.Instance.currentLevel++;
            UIManager.Instance.LevelCompleteScreen();
            LevelManager.Instance.UpdateSlowMotionCount();
        }

        private void GetStartingValue()
        {
            _startingColor = wholeCirclePrefab.GetComponent<Renderer>().material.color;
            _startingTargetPieceColored = targetPieceColored;
        }
    }
}


