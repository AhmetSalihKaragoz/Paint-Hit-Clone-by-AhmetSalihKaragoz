using System;
using Managers;
using Unity.Mathematics;
using UnityEngine;

namespace Ball
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject ballPrefab;
        private void Start()
        {
            GetFirstBall();
        }
        
        public void SpawnBall()
        {
            DestroyOldBall();
            var instance = Instantiate(ballPrefab, new Vector3(0, 0, -8), quaternion.identity,gameObject.transform);
            instance.GetComponentInChildren<Renderer>().material.color =
                ColorManager.Instance.GetCurrentColor();
        }

        public void DestroyOldBall()
        {
            var childs  = transform.childCount;
            for (var i = childs - 1; i >= 0; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
        private void GetFirstBall()
        {
            var instance = Instantiate(ballPrefab, new Vector3(0, 0, -8), quaternion.identity,gameObject.transform);
            instance.GetComponentInChildren<Renderer>().material.color =
                ColorManager.Instance.GetCurrentColor();
        }
    
    }
}
