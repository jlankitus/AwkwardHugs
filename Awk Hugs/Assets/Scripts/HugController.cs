using RootMotion.FinalIK;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugController : MonoBehaviour
{
    public InteractionObject leftHandTarget;
    public InteractionObject leftShoulderTarget;
    public InteractionObject rightHandTarget;
    public InteractionObject rightShoulderTarget;

    private InteractionSystem interactionSystem;

    [Tooltip("The effectors to interact with")]
    [SerializeField] FullBodyBipedEffector leftHandEffector;
    [SerializeField] FullBodyBipedEffector rightHandEffector;
    [SerializeField] FullBodyBipedEffector leftShoulderEffector;
    [SerializeField] FullBodyBipedEffector rightShoulderEffector;

    public Transform HugTarget;
    public float MaxHugDistance = 5.0f;

    void Awake()
    {
        interactionSystem = GetComponent<InteractionSystem>();
    }

    [ContextMenu("Left Hug")]
    public void LeftHug()
    {
        interactionSystem.StartInteraction(leftHandEffector, leftHandTarget, true);
        interactionSystem.StartInteraction(rightHandEffector, rightHandTarget, true);
        interactionSystem.StartInteraction(leftShoulderEffector, leftShoulderTarget, true);
        // interactionSystem.StartInteraction(rightShoulderEffector, leftHandTarget, true);
    }

    [ContextMenu("Right Hug")]
    public void RightHug()
    {
        interactionSystem.StartInteraction(leftHandEffector, leftHandTarget, true);
        interactionSystem.StartInteraction(rightHandEffector, leftHandTarget, true);
        interactionSystem.StartInteraction(leftShoulderEffector, leftHandTarget, true);
        interactionSystem.StartInteraction(rightShoulderEffector, leftHandTarget, true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(CheckIfInRange())
                LeftHug();
        }
    }

    private bool CheckIfInRange()
    {
        Debug.Log((HugTarget.position - gameObject.transform.position).magnitude);
        if (Math.Abs((HugTarget.position - gameObject.transform.position).magnitude) <= MaxHugDistance)
            return true;
        else return false;
    }
}
