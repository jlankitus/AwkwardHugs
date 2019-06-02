using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;

public class Hug : MonoBehaviour
{
    public FullBodyBipedIK ik;

    public Transform leftHandTarget, rightHandTarget;

    private void LateUpdate()
    {
        // Set left hand target to be the effector on the left hand
        ik.solver.leftHandEffector.position = leftHandTarget.position;
        ik.solver.leftHandEffector.rotation = leftHandTarget.rotation;
        ik.solver.leftHandEffector.positionWeight = 1f;
        ik.solver.leftHandEffector.rotationWeight = 1f;

        // Set right hand target to be the effector on the right hand
        ik.solver.rightHandEffector.position = rightHandTarget.position;
        ik.solver.rightHandEffector.rotation = rightHandTarget.rotation;
        ik.solver.rightHandEffector.positionWeight = 1f;
        ik.solver.rightHandEffector.rotationWeight = 1f;
    }
}
