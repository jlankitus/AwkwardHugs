using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    [Tooltip("Insert the opponent's transform component here")]
    [SerializeField] Transform opponent;

    [Tooltip("How fast the player can move")]
    [Range(0.5f,5.0f)]
    [SerializeField] float playerMovementSpeed = 2.5f;

    [Tooltip("How far or close the player can get to the opponent (in units)")]
    [Range(0.30f,5.0f)]
    [SerializeField] float furthestPositionOffset, closestPositionOffset;

    [SerializeField] string action1InputName, action2InputName, action3InputName;

    

    /// <summary>
    /// Cached reference to the furthest / closest position the player can be from the opponent
    /// </summary>
    Vector3 furthestPosition, closestPosition;
    

    private void Awake()
    {
        furthestPosition = opponent.position;
        closestPosition = opponent.position;

        furthestPosition.z += furthestPositionOffset;
        closestPosition.z += closestPositionOffset;


        transform.position = furthestPosition;

    }

    private void Update()
    {
        /*
        if(GameManager.mainGameManager.CurrentGamePhase == GamePhase.TensionPhase)
        {
            TensionPhasePlayerControl();
        }
        else
        {
            HugPhasePlayerControl();
        }
        */
        TensionPhasePlayerControl();
    }

    /// <summary>
    /// Method to call for player control when the tension phase is active
    /// </summary>
    void TensionPhasePlayerControl()
    {

        float verticalAxis = Input.GetAxis("Vertical");
        GetComponent<Animator>().SetFloat("movement", verticalAxis);

        // Move backwards if the input is less than 0
        if (verticalAxis < 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, furthestPosition, playerMovementSpeed * Time.deltaTime);
            
        }
        else if(verticalAxis > 0) // Move forward if the input is greater than 0
        {
            transform.position = Vector3.MoveTowards(transform.position, closestPosition, playerMovementSpeed * Time.deltaTime);
            
        }
        /*
        else if (Input.GetButtonDown(action1InputName)) // If action button 1 is pressed, perform the action
        {
            Debug.Log("Action 1 performed!");
        }
        else if (Input.GetButtonDown(action2InputName)) // If action button 2 is pressed, peform the action
        {
            Debug.Log("Action 2 performed!");
        }
        else if(Input.GetButtonDown(action3InputName)) // If action button 2 is pressed, perform the action
        {
            Debug.Log("Action 3 performed!");
        }
        */

    }



    /// <summary>
    /// Method to call for player control when the hug phase player control is active
    /// </summary>
    void HugPhasePlayerControl()
    {


    }




}
