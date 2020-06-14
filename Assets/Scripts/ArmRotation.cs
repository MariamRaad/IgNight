using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    private Camera _camera;
    public float rotationOffset;
    
    private void Start()
    {
        _camera = Camera.main;
        if (_camera == null)
        {
            Debug.LogError("No main camera to point at!");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
        // subtracting player from mouse position
        var difference = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        // Normalizing vector. Meaning sum of all axes will be equal to 1.
        difference.Normalize();

        // Find the angle in Radians and convert to Degrees
        var rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + rotationOffset);
    }
}