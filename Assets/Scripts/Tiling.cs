using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Tiling : MonoBehaviour
{
    public int offsetX = 2; // offset so we dont get weird errors?

    public bool hasRightBuddy = false;
    public bool hasLeftBuddy = false;

    public bool reverseScale = false; // used if object is not tilable

    private float spriteWidth = 0.0f; // width of element
    private Camera mainCamera;
    private Transform myTransform;

    private void Awake()
    {
        mainCamera = Camera.main;
        myTransform = transform;
    }

    // Start is called before the first frame update
    private void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = spriteRenderer.sprite.bounds.size.x;
    }

    // Update is called once per frame
    private void Update()
    {
        // do we still need buddies?
        if (!hasLeftBuddy || !hasRightBuddy)
        {
            // calculate camera extend (half the width) of what camera can see in world coordinates
            var cameraHorizontalExtend = mainCamera.orthographicSize * Screen.width / Screen.height;

            // calculate the x position where the camera can see the edge of sprite (element)
            var myPosition = myTransform.position;
            var edgeVisiblePositionRight = (myPosition.x + spriteWidth / 2) - cameraHorizontalExtend;
            var edgeVisiblePositionLeft = (myPosition.x - spriteWidth / 2) + cameraHorizontalExtend;

            // checking if we can see the edge of the element and then call makeNewBuddy
            if (mainCamera.transform.position.x >= edgeVisiblePositionRight - offsetX && !hasRightBuddy)
            {
                makeNewBuddy(1);
                hasRightBuddy = true;
            } else if (mainCamera.transform.position.x <= edgeVisiblePositionLeft + offsetX && !hasLeftBuddy)
            {
                makeNewBuddy(-1);
                hasLeftBuddy = true;
            }
        }
    }

    /// <summary>
    /// Creates a new Buddy
    /// </summary>
    /// <param name="rightOrLeft"></param>
    private void makeNewBuddy(int rightOrLeft)
    {
        // calculating the new position
        var myPosition = myTransform.position;
        var newPosition = new Vector3(myPosition.x + spriteWidth * rightOrLeft, myPosition.y, myPosition.z);
        // instantiate a new Buddy
        var newBuddy = Instantiate(myTransform, newPosition, myTransform.rotation);
        newBuddy.tag = "ParallaxChild";

        if (reverseScale)
        {
            var newBuddyLocalScale = newBuddy.localScale;
            newBuddyLocalScale = new Vector3(newBuddyLocalScale.x * -1, newBuddyLocalScale.y, newBuddyLocalScale.z);
            newBuddy.localScale = newBuddyLocalScale;
        }
        
        // if not tilable reverse the x size of our object to get rid of ugly seams
        var parent = myTransform.parent;
        newBuddy.parent = parent.CompareTag("ParallaxChild") ? parent : myTransform;
        
        if (rightOrLeft > 0)
        {
            newBuddy.GetComponent<Tiling>().hasLeftBuddy = true;
        }
        else
        {
            newBuddy.GetComponent<Tiling>().hasRightBuddy = true;
        }
    }
}