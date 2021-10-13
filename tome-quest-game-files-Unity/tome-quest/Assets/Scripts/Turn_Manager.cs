using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Turn_Manager : MonoBehaviour
{

    //Mostly for Generating Markers\\
    public GameObject Turn_Marker;
    private GameObject[] player_turns;
    private GameObject[] enemy_turns;
    private GameObject[] turns;
    float[] initiative_Values;
    public string[] names;
    public List<GameObject> turn_markers;
    

    //Moslty for getting dimensions and positions\\
    private Rect dimensions;
    public float max_action_time;
    public GameObject slider;
    private Vector3 p_initiative;
    public GameObject Canvas;
    private float max_value;
    private float current_value;

    //For the Timer\\
    public static float time;
    public float max_time;
    public bool action;
    public float variable_time = 0.1f;

    ///For Checking Turn Happening and Action Stuff\\\\
    public bool turn_is_happening;
    public float next_turn;
    public float action_duration;

    //private float action_max_time;
    private float action_time;
    private bool need_action_time = false;



    void Start()
    {

        //Stores all gameobjects which need turn markers into arrays, enemy and player, then concactinates them\\
        if  (turns == null)
        {
            player_turns = GameObject.FindGameObjectsWithTag("player");
            enemy_turns = GameObject.FindGameObjectsWithTag("enemy");
            turns = player_turns.Concat(enemy_turns).ToArray();


        }

        //Grabs the Initiative Values and Names and Action_Duration of the Objects\\
        initiative_Values = new float[turns.Length];
        names = new string[turns.Length];
        turn_markers = new List<GameObject>();

        
        for (int i = 0; i < turns.Length; i++)
        {
            initiative_Values[i] = turns[i].GetComponent<initiative_value>().initiative;
            names[i] = turns[i].name;
            
            
        }


        //Grabs the dimensions of the slider bar, and the Max value of the slider, aka initiative \\
        dimensions = slider.GetComponent<RectTransform>().rect;
        max_value = slider.GetComponent<Slider>().maxValue;
        // current_value = slider.GetComponent<Slider>().value;
        current_value = max_value;



        ////////////////////////////////-----////////////////////////////////////



        //Generates, moves, and names all the shit my doods\\
        foreach (GameObject turn in turns)
        {
            GameObject turn_marker = Instantiate(Turn_Marker, slider.transform.position, slider.transform.rotation, slider.transform);
            turn_marker.name = turn.name;
            turn_markers.Add(turn_marker);

            turn_marker.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
            turn_marker.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
             
            turn_marker.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
            
            turn_marker.GetComponent<prefab_script>().initiative = turn.GetComponent<initiative_value>().initiative;

            if (turn.tag == "player")
            {
                turn_marker.GetComponent<RectTransform>().anchoredPosition = new Vector3(1.5f, -20f, 0f);
            }
            else
            {
                turn_marker.GetComponent<RectTransform>().anchoredPosition = new Vector3(1.5f, -3f, 0f);
            }
            p_initiative = turn_marker.GetComponent<RectTransform>().anchoredPosition;
            
            p_initiative.x = ((turn_marker.GetComponent<prefab_script>().initiative * dimensions.width) / max_value);

            
            turn_marker.GetComponent<RectTransform>().anchoredPosition = p_initiative;
            

            

        }

        //Time Stuff Obvs\\
        time = max_time;
        




    }

    // Update is called once per frame\\
    void FixedUpdate()
    {

        //Yarr this be the timer and Turn Checker\\

        next_turn = initiative_Values.Max();

        for (int i = 0; i < turns.Length; i++)
        {
            
            if (turns[i].GetComponent<initiative_value>().initiative == next_turn)
            {
                action_duration = turns[i].GetComponent<initiative_value>().action_duration;
                
            }
        }



            if (current_value <= next_turn)
        {
            turn_is_happening = true;
            
            

            if (action_time >= 0)
            {

            }


        }
        
        if (time >= 0 && turn_is_happening == false)
        {
            time -= (0.02f);
            

        }
        ///// Sets the Bar Position\\\\\\\\\
        current_value = time * max_value / max_time;
        slider.GetComponent<Slider>().value = current_value;
    }
}
