using RootMotion.FinalIK;
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
            LeftHug();
        }
    }
}
