using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 10f);
    }
	private void OnTriggerEnter()
	{
		gameObject.SetActive(false);
	}
}
