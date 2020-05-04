using System.Collections.Generic;
using UnityEngine;
using System;

public class objectScript : MonoBehaviour
{
   
    int timeLeft = 0;
    int time_to_death = 0;
    int id = 0;
    /*
    private void Start()
    {
        GameEvents.current.onTimerTimeout += 
    }
    signal timeout

    func set_time_to_death(time: int):

        time_to_death = time

    func my_object_id(x) :

        id = x

    func death() :

        print("Jestem obiektem na pozycji nr: ", id ,"", " i wsłaśnie umarłem.")

        queue_free()

    func _ready():

        pass

    func _process(delta) :

        time_left += delta

	    if time_left > time_to_death:
		    emit_signal("timeout", id, self)

            time_left = 0


    */
    // Update is called once per frame
    void Update()
    {
        
    }
}
