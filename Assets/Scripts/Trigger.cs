using System.Collections;
using System.Collections.Generic;
using Circle;
using Managers;
using UI;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private bool _isUsed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_isUsed) return;
        if (!other.CompareTag("circle")) return;
        if (!other.GetComponent<CirclePiece>().isColored)
        {
            other.GetComponent<CirclePiece>().ballSpawner.SpawnBall();
            //ColorManager.Instance.SetCirclePieceColor(other.gameObject);
            ColorManager.Instance.ClearSplash();
            ColorManager.Instance.triggeredPieceList.Add(other.gameObject);
            other.GetComponent<CirclePiece>().isColored = true;
            _isUsed = true;
        }
        else if (other.GetComponent<CirclePiece>().isColored)
        {
            other.GetComponent<CirclePiece>().ballSpawner.SpawnBall();
            UIManager.Instance.LoadGameOverScreen();
        }
    }
    


    // ReSharper disable Unity.PerformanceAnalysis
}
