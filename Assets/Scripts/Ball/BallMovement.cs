using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Ball
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private float force;
        private Rigidbody _rb;
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            MoveBall();
       
        }
        // ReSharper disable Unity.PerformanceAnalysis
        private void MoveBall()
        {
            if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
            {
                _rb.AddForce(transform.forward*force);
            }
        }
        
        private bool IsPointerOverUIObject() {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);

            eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            List<RaycastResult> results = new List<RaycastResult>();

            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

            return results.Count > 0;
        }


    }
}
