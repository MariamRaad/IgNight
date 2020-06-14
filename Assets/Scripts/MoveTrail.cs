using UnityEngine;

public class MoveTrail : MonoBehaviour
{
    public float movementSpeed = 200;

    private void Start()
    {
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Time.deltaTime * movementSpeed * Vector3.right);
    }
}
