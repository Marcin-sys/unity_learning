using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class SpawnCircle2 : MonoBehaviour
{
    
    // Start is called before the first frame update
    #region fields
    // time limit's
    int timeSpanMax = 1;                          // time period max till function spawn another object
    int timeSpanMin = 1;                          // time period min till function spawn another object
    int timeSpan;                                  // time period till function spawn another object
    float timeLeft = 0;                              // timer
    float setTimeToDeathMax = 25f;
    float setTimeToDeathMin = 10f;

    // circle
    float radius = 20;                                // circle radius

    Vector3 center = new Vector3(0, 0, 0);                               // circle center
    float count_segments = 20;                        // how much of an angle objects will be spaced around the circle.
    float angle_step;
    // number of object's
    int node_counter;                               // for counting the number of objects on the screen
    int number_of_object_can_spawn;                 // random number from min to max that can spawn inside of circle
    int number_of_object_max = 20;                  // max number of object that can spawn inside circle
    int number_of_object_min = 10;                  // min number of object that can spawn inside circle

    int temporary;
    //var rng = randomnumbergenerator.new ()  			# make seed for number.

    List<int?> store_flag = new List<int?>();                             // store position of spawned object
    int position_object_edge_circle;


    List<Vector3> positionList = new List<Vector3>();
    int objects_in_scene = 0;
    int random_position_id;

    [SerializeField] private List<GameObject> objecttoSpawm;

    #endregion 
    void Start()
    {
        angle_step = (float)(2.0 * Math.PI / count_segments);   // 2.0*pi = 360 degrees  / segments

        GenerateArray();

        timeSpan = UnityEngine.Random.Range(timeSpanMin, timeSpanMax);

        Debug.Log("Time to first spawn:" + timeSpan + "s");
    }

    private void GenerateArray()
    {
        for (int i = 0; i < count_segments; ++i)                 // generate array with posible position for count_segments
        {
            positionList.Add(new Vector3(Mathf.Cos(i), 0, Mathf.Sin(i)) * radius + center);
            store_flag.Add(null);
        }
    }

    private int GenerateObject()
    {
        

        int random_position_id = UnityEngine.Random.Range(0, positionList.Count - 1);  // random position for object


        if (store_flag[random_position_id] == null)
        {
            Vector3 position_for_temp = positionList[random_position_id];                   // position for temp

            GameObject temporary_object = Instantiate(objecttoSpawm[UnityEngine.Random.Range(0, objecttoSpawm.Count)]);
            temporary_object.transform.position = position_for_temp;
            store_flag[random_position_id] = 1;                                          // change null to 1 in store_flag [random_position_id]
           
            VolatileObject temp = temporary_object.GetComponent<VolatileObject>();
            temp.SetTimeToDeath(UnityEngine.Random.Range(setTimeToDeathMin, setTimeToDeathMax));

            temp.MyObjectId(random_position_id);
			temp.OnTimeout.AddListener(OnObjectTimeout);
			return 0;
        }
        else
        {
            return 1;
        }
    }
    
    public void OnObjectTimeout(VolatileObject obj, int id)
    {
        if (objects_in_scene > number_of_object_min)
        {
            store_flag[id] = null;   // clear position in  storeFlaf
			obj.DestroyGameObject();
			objects_in_scene -= 1;
			//referance.death();
			Debug.Log("ilosc obiektow: " + objects_in_scene);
        }
    }

	// Update is called once per frame
	void Update()
    {
        timeLeft += Time.deltaTime;

        if (timeLeft > timeSpan)
        {
            // Random time
            timeSpan = UnityEngine.Random.Range(timeSpanMin, timeSpanMax);

            // Reset time_left.
            timeLeft = 0;
            
            int result = GenerateObject();
            
            // If in time limit nothing spawn then fast forward.
            if (result == 1)
            {
                timeSpan = 0;
            }
            else if (objects_in_scene < number_of_object_max)
            {
                objects_in_scene += 1; // count objects
                //Debug.Log("Time to next spawn:" + timeSpan + "s");

                Debug.Log("ilosc obiektow: " + objects_in_scene);
            }
            
        }
    }



}
