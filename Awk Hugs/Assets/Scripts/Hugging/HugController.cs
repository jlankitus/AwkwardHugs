using RootMotion.FinalIK;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugController : MonoBehaviour
{
    // Objects that we actually reach for
    public InteractionObject leftHandTarget;
    public InteractionObject leftShoulderTarget;
    public InteractionObject rightHandTarget;
    // public InteractionObject rightShoulderTarget;

    // The core system
    private InteractionSystem interactionSystem;

    [Tooltip("The effectors to interact with")]
    [SerializeField] FullBodyBipedEffector leftHandEffector;
    [SerializeField] FullBodyBipedEffector rightHandEffector;
    [SerializeField] FullBodyBipedEffector leftShoulderEffector;
    // [SerializeField] FullBodyBipedEffector rightShoulderEffector;
    [SerializeField] AudioClip [] happyHugAudioClips;
    [SerializeField] AudioClip[] sadAudioClip;

    public float MaxHugDistance = 5.0f;

    // Did we find a target in range?
    public bool foundTarget = false;
    public GameObject target;
    private HugVictim targetHugVictim;

    public float destroyVictimAfterSeconds = 2.0f;

    public delegate void HugSuccess();
    public event HugSuccess OnSuccessfulHug;
    
    void Awake()
    {
        interactionSystem = GetComponent<InteractionSystem>();
    }

    // THIS IS THE MOFUCKIN HUG
    [ContextMenu("Left Hug")]
    public void LeftHug()
    {
        if (foundTarget)
        { 
            interactionSystem.StartInteraction(leftHandEffector, leftHandTarget, true);
            interactionSystem.StartInteraction(rightHandEffector, rightHandTarget, true);
            interactionSystem.StartInteraction(leftShoulderEffector, leftShoulderTarget, true);
            targetHugVictim.sadParticles.SetActive(false);
            PlayHugClip();
            targetHugVictim.happyParticles.SetActive(true);
            StartCoroutine(KillWithJoy(targetHugVictim));
            
            // Call hug successful event
            OnSuccessfulHug?.Invoke();
        }
    }
    
    /// <summary>
    /// Method called to play a happy hug audio clip
    /// </summary>
    void PlayHugClip()
    {
        GetComponent<AudioSource>().PlayOneShot(happyHugAudioClips[UnityEngine.Random.Range(0, happyHugAudioClips.Length)]);
    }

    private IEnumerator KillWithJoy(HugVictim victim)
    {
        yield return new WaitForSeconds(destroyVictimAfterSeconds);
        victim.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (foundTarget)
            {
                if(CheckIfInRange())
                    LeftHug();
            }
        }
    }

    private bool CheckIfInRange()
    {
        Debug.Log((target.transform.position - gameObject.transform.position).magnitude);
        if (Math.Abs((target.transform.position - gameObject.transform.position).magnitude) <= MaxHugDistance)
            return true;
        else return false;
    }

    void OnCollisionEnter(Collision collision)
    {
        // If the collision is our 'Wandering Soul' prefab....
        if (collision.gameObject.name.Contains("Wandering"))
        {
            // If the target hasn't been set yet, set it
            if(!target || target != collision.gameObject)
            {
                foundTarget = true;
                target = collision.gameObject;
                targetHugVictim = target.GetComponent<HugVictim>();
                SetTargetsToVictim(targetHugVictim);
            }
            Debug.Log("Targeted victim: " + target.name);
        }
    }

    private void SetTargetsToVictim(HugVictim victim)
    {
        leftHandTarget = targetHugVictim.leftHandTarget;
        rightHandTarget = targetHugVictim.rightHandTarget;
        leftShoulderTarget = targetHugVictim.leftShoulderTarget;
        
        if(targetHugVictim.sadParticles.activeInHierarchy == false)
        {
            targetHugVictim.sadParticles.SetActive(true);
            PlaySadClip();
        }
        
        Debug.Log("set targets!");
    }

    void PlaySadClip()
    {
        
        GetComponent<AudioSource>().PlayOneShot(sadAudioClip[UnityEngine.Random.Range(0, sadAudioClip.Length)]);
    }
}
