using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Tooltip("Player's transform reference")]
    [SerializeField] Transform playerTransform;

    /// <summary>
    /// The offset distance between the player's position and the camera, this offset will always be maintained
    /// </summary>
    Vector3 cameraOffset;

    private void Awake()
    {
        // Initialize the camera offset by subtracting the player's position with the camera's position
        cameraOffset = playerTransform.position - this.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        // Maintain the camera's position by offsetting the player transform from the offset originally initialized
        transform.position = playerTransform.position - cameraOffset;
    }
}
