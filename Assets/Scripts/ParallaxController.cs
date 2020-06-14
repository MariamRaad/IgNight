using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public Transform[] backgrounds; // backgrounds and foregrounds to be parallaxed
    private float[] parallaxScales; // Proportion of camera's movement to move the backgrounds
    public float smoothing = 1.0f; // sets smoothness

    private Transform mainCamera; // ref to main camera to transform
    private Vector3 previousCameraPosition; // the position of the camera in previous frame


    // Called before initialization, great for references
    private void Awake()
    {
        // init references
        mainCamera = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        // previous frame has current camera position
        previousCameraPosition = mainCamera.position;

        parallaxScales = new float[backgrounds.Length];
        for (var i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < backgrounds.Length; i++)
        {
            // parallax is opposite to camera movement
            var parallax = (previousCameraPosition.x - mainCamera.position.x) * parallaxScales[i];

            // set target x position which is current + parallax
            var backgroundTargetPositionX = backgrounds[i].position.x + parallax;

            // create target position
            var backgroundTargetPosition = new Vector3(backgroundTargetPositionX, backgrounds[i].position.y,
                backgrounds[i].position.z);

            // fade between current position and target position
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPosition,
                smoothing * Time.deltaTime);
        }
        
        // set previous camera position to cameras position at the end of the frame7
        previousCameraPosition = mainCamera.position;
    }
}