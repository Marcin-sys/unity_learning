using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerFollowing : MonoBehaviour
{
	[SerializeField] private Vector3 pointerPosition;
    void Start()
    {
        
    }
	private void Update()
	{
		pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pointerPosition.Set(pointerPosition.x, pointerPosition.y, 0);
		transform.LookAt(pointerPosition);
	}
}
