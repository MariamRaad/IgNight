using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.U2D;

public class SimpleSpriteShapeAnimation : MonoBehaviour
{
    public int fps = 60;
    public int nextSprite;
    public List<Sprite> sprites;
    
    private SpriteShapeController spriteShape;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        spriteShape = GetComponent<SpriteShapeController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        var waitTime = 1.0f / fps;

        if (!(timer > waitTime)) return;
        timer -= waitTime;
        
        spriteShape.spriteShape.angleRanges[0].sprites[0] = sprites[nextSprite];
        nextSprite++;
        
        if (nextSprite >= sprites.Count)
        {
            nextSprite = 0;
        }

        
    }
}