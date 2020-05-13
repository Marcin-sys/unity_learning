using UnityEngine;
using UnityEngine.Events;
using System;

[System.Serializable]
public class TimeoutEvent : UnityEvent<VolatileObject, int>
{
}
public class VolatileObject : MonoBehaviour
{
	[SerializeField] public TimeoutEvent OnTimeout = new TimeoutEvent();
	// Start is called before the first frame update
	#region fields
	[SerializeField] private float timeLeft = 0;
    [SerializeField] private float timeToDeath = 0;
    [SerializeField] private int id = 0;
    #endregion
    public void SetTimeToDeath(float time)
    {
        timeToDeath = time;
    }

    public void MyObjectId(int x)
    {
        id = x;
    }

    public void DestroyGameObject()
    {
        Debug.LogWarning("Jestem obiektem na pozycji nr:" + id + " i właśnie umarłem");
		Debug.LogWarning(name);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft += Time.deltaTime;
        if (timeLeft > timeToDeath && OnTimeout != null)
        {
			// wystartuj z eventem 
			OnTimeout?.Invoke(this, id);
            timeLeft = 0;
        }
    }
}
