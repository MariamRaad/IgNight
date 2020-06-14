using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FeuerbodenController : MonoBehaviour
{
    private PolygonCollider2D myCollider;
    
    public LayerMask m_whatIsPlayer; // A mask determining what is ground to the character
    public Transform firePrefab;

    public Vector3 offset;
//    public SortingLayer sortingLayer;
//    public int sortingOrder;


    // Start is called before the first frame update

    void Start()
    {
        myCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ContactFilter2D filter2D = new ContactFilter2D();
        filter2D.layerMask = m_whatIsPlayer;

        List<Collider2D> hitObjects = new List<Collider2D>();
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        var resultCount = Physics2D.OverlapCollider(myCollider, filter2D, hitObjects);
        for (int i = 0; i < hitObjects.Count; i++)
        {
            if (hitObjects[i].gameObject != gameObject)
            {
                var pos = new Vector3(hitObjects[i].transform.position.x, hitObjects[i].transform.position.y, 1) + offset;
                //var fire = Instantiate(firePrefab, pos, Quaternion.Euler(0,0,0));
                
                
                
                break;
            }
        }
    }
}
