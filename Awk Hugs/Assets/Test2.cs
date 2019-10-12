using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public bool hazCubanBread = true;
    public bool hazWheatBread = true;
    public bool hazMeatAndMustardAndSwiss = true;
    public bool gotoStore = false;
    public bool ovenOn = false;
    public bool hazButterknife = true;
    public bool hazSharpknife = true;

    void Start()// Start is called before the first frame update
    // Start is called before the first frame update
    {
        print("It's Week 3!!");
        print("My name is LEYANIS!!");
        print("I will make a Cubano Sandwich for you");
        print("Preheat baking oven for 300 degree temperature)");
        ovenOn = true;
        print("Grab a plate & place the plate down on Countertop");
        print("Go to Fridge");
        print("Open Fridge");

        if (hazCubanBread)
        {
            print("Grab two slices of cuban bread");
            print("Separate cuban bread onto Plate onto L & R");
        }
        else if (hazWheatBread)
        {
            print("Has no Cuban Bread, alterante Wheat Bread");
            print("Grab wheat bread");
            print("Separate wheat bread onto Plate onto L & R");
        }

        if (hazMeatAndMustardAndSwiss)
        {
            print("Grab Yellow Mustard and spread on L Bread");
            print("Grab on slice of ham and place on L bread");
            print("Grab a slice of roasted pork & place on R bread");
            print("Grab slice of swiss cheese & place on L bread");
        }
        else
        {
            print("Not enough ingredients");
            if (ovenOn == true)
            {
                print("TurnoffOven");
                ovenOn = false;
            }
            print("Go to the Store");
            gotoStore = true;
        }

        if (gotoStore == false)
        {
            print("Take L bread with components and place reverse on top of bread");
            print("Take sandwich and flatten slightly");
            print("Grab plate with Sandwich, Open baking oven, place sandwich onto plate, heat for 10 minutes on 300 degree temperature");
            print("Remove sandwich from oven");
            ovenOn = false;
        }

            if (hazButterknife == true || hazSharpknife == true)
                {
                print("Grab a knife and use to cut sandwich in Half");
                print("Give plate with sandwhich to Leo once plate cools is >10 degree of room temperature");
            }

            if (hazButterknife == false && hazSharpknife == false)
            {
                print("No knives are clean, washing knives");
                print("Grab a knife and use to cut sandwich in Half");
                print("Give plate with sandwhich to Leo once plate cools is >10 degree of room temperature");
            }
    }

    // Update is called once per frame
    void Update()
    { 
    }
}

