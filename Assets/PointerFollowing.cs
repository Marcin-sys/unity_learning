using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerFollowing : MonoBehaviour
{
	[SerializeField] private Vector3 pointerPosition;
	[SerializeField] private Transform gunTip;
	[SerializeField] private GameObject bullet;

	private void Update()
	{
		pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pointerPosition.Set(pointerPosition.x, pointerPosition.y, 0);
		transform.LookAt(pointerPosition);

		if (Input.GetMouseButtonDown(0))
		{
			FireBullet();
		}
	}
	private void FireBullet()
	{
		//GameObject firedBullet = Instantiate(bullet, gunTip.position, gunTip.rotation);
		//firedBullet.GetComponent<Rigidbody>().velocity = gunTip.up * 10f;
		PoolManager.Instance.ReuseObject(bullet, gunTip.position, gunTip.rotation);
		
	}
}
