using System;
using Ball;
using DG.Tweening;
using Managers;
using UnityEngine;

namespace Circle
{
    public class CirclePiece : MonoBehaviour
    {
        public BallSpawner ballSpawner;
        [HideInInspector] public bool isColored = false;

        private void Start()
        {
            
        }
    }
}
