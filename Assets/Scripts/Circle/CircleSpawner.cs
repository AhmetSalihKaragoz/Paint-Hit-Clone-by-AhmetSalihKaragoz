using System;
using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Circle
{
    public class CircleSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject circlePrefab;
        [SerializeField] private List<GameObject> triggerObjects = new List<GameObject>();
        
        private int _yPosCounter = -1;
        private List<GameObject> spawnedCircles = new List<GameObject>();
        
        public void SpawnCircle()
        {
            var circle = Instantiate(circlePrefab, new Vector3(0, 0, 0), 
                Quaternion.identity, gameObject.transform);
            circle.GetComponentInChildren<Renderer>().material.color = ColorManager.Instance.GetCurrentColor();
            RelocateCircle(circle);
            spawnedCircles.Add(circle);
        }

        public void CleanCircleList()
        {
            foreach (var circle in spawnedCircles)
            {
                Destroy(circle);
            }

            _yPosCounter = -1;
        }
        private void RelocateCircle(GameObject circle)
        {
            var newCirclePos = circle.transform.position;
            newCirclePos.y = _yPosCounter;
            circle.transform.position = newCirclePos;
            _yPosCounter--;
        }
        
        
    }
}
