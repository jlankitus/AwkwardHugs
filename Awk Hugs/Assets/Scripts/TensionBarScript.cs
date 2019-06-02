using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class used to manipulate a character's tension
/// </summary>
[RequireComponent(typeof(Animator))]
public class TensionBarScript : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Slider tentionUI;
    /// <summary>
    /// The value of the tension meter
    /// </summary>
    [Range(0.0f, 1.0f)]
    [SerializeField]
    float tensionMeter = 0.0f;

    /// <summary>
    /// The string name of the tension variable within the animator component
    /// </summary>
    [Tooltip("The name of the animator's tension variable")]
    [SerializeField]
    string tensionVariableName;

    /// <summary>
    /// Cached reference to the character's animator component
    /// </summary>
    private Animator characterAnimator;
    
    private void Awake()
    {
        tentionUI.value = tensionMeter;
        characterAnimator = this.GetComponent<Animator>();
    }

    /// <summary>
    /// Method called to change the tension of the character by the added amount
    /// Note: A positive number passed in adds tension, a negative number passed in deducts tension
    /// Note: Tension cannot exceed 100 or go below 0
    /// </summary>
    /// <param name="tensionChangeAMT"></param>
    public void ChangeTension(float tensionChangeAMT)
    {
        tensionMeter = Mathf.Clamp01(tensionMeter + tensionChangeAMT);
        
    }





    private void Update()
    {
        characterAnimator.SetFloat(tensionVariableName, tensionMeter);
        tentionUI.value = tensionMeter;
    }


}
