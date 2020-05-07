﻿using UnityEngine;
using UnityEngine.Events;
public class ObjectLive : MonoBehaviour
{
    UnityEvent TimeoutEvent;
    // Start is called before the first frame update
    #region fields
    float timeLeft = 0;
    int timeToDeath = 0;
    int id = 0;
    #endregion


    private void Start()
    {

    }

    public void SetTimeToDeath(int time)
    {
        timeToDeath = time;
    }

    public void MyObjectId(int x)
    {
        id = x;
    }

    public void Death()
    {
        Debug.LogWarning("Jestem obiektem na pozycji nr:" + id + " i właśnie umarłem");
        Destroy(this);
    }
    // Update is called once per frame
    void Update()
    {
        timeLeft += Time.deltaTime;
        if (timeLeft > timeToDeath)
        {
            // wystartuj z eventem 
            TimeoutEvent.Invoke();
            timeLeft = 0;
        }
    }
}