using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCamera;
    private UnityEngine.AI.NavMeshAgent player;

    private void Start()
    {
        mainCamera = Camera.main;
        player = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            Vector3 targetPosition = GetTargetPosition();
            if (targetPosition != Vector3.zero)
            {
                player.SetDestination(targetPosition);
            }
        }
    }

    private Vector3 GetTargetPosition()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                if (Physics.Raycast(mainCamera.ScreenPointToRay(touch.position), out hit))
                {
                    return hit.point;
                }
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                return hit.point;
            }
        }

        return Vector3.zero;
    }
}
