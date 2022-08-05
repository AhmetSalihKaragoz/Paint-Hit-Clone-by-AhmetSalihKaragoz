using DG.Tweening;
using UnityEngine;

namespace Circle
{
    public class CircleMovement : MonoBehaviour
    {
        private void Start()
        {
            CircleMove();
        }
        void CircleMove()
        {
            transform.DORotate(Vector3.up * 359, 3f).OnComplete(() =>
            {
                transform.DORotate(Vector3.down * 359, 3f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
            });
        }
    }
}


