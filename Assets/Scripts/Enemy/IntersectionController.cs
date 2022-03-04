using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionController : MonoBehaviour
{
    private Bounds colliderBounds;
    private float leftX;
    private float rightX;
    private float topY;
    private float bottomY;
    
    private void Awake()
    {
        colliderBounds = GetComponent<BoxCollider2D>().bounds;
        leftX = colliderBounds.center.x - colliderBounds.extents.x;
        rightX = colliderBounds.center.x + colliderBounds.extents.x;
        topY = colliderBounds.center.y + colliderBounds.extents.y;
        bottomY = colliderBounds.center.y - colliderBounds.extents.y;
    }

    public float GetLeftX()
    {
        return leftX;
    }
    
    public float GetRightX()
    {
        return rightX;
    }
    
    public float GetTopY()
    {
        return topY;
    }
    
    public float GetBottomY()
    {
        return bottomY;
    }
}
