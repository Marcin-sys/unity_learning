using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kolid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            GameObject trigerredObject = other.attachedRigidbody.gameObject;
            trigerredObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
