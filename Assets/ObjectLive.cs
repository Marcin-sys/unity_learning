using UnityEngine;
using UnityEngine.Events;
using System;
public class ObjectLive : MonoBehaviour
{
	public event Action<ObjectLive, int> OnDeathEvent;
	// Start is called before the first frame update
	#region fields
	[SerializeField] private float timeLeft = 0;
    [SerializeField] private float timeToDeath = 0;
    [SerializeField] private int id = 0;
    #endregion

    private void Start()
    {

    }

    public void SetTimeToDeath(float time)
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
            OnDeathEvent.Invoke(this, id);
            timeLeft = 0;
        }
    }
}
