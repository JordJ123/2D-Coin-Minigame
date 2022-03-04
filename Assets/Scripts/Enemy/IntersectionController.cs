using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionController : MonoBehaviour
{
    private Bounds intersectionBounds;
    private float intersectionLeftX;
    private float intersectionRightX;
    private float intersectionTopY;
    private float intersectionBottomY;
    
    private void Awake()
    {
        intersectionBounds = GetComponent<BoxCollider2D>().bounds;
        intersectionLeftX = intersectionBounds.center.x - intersectionBounds.extents.x;
        intersectionRightX = intersectionBounds.center.x + intersectionBounds.extents.x;
        intersectionTopY = intersectionBounds.center.y + intersectionBounds.extents.y;
        intersectionBottomY = intersectionBounds.center.y - intersectionBounds.extents.y;
    }

    public float GetIntersectionLeftX()
    {
        return intersectionLeftX;
    }
    
    public float GetIntersectionRightX()
    {
        return intersectionRightX;
    }
    
    public float GetIntersectionTopY()
    {
        return intersectionTopY;
    }
    
    public float GetIntersectionBottomY()
    {
        return intersectionBottomY;
    }
}
