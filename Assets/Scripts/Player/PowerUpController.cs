using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player.SpriteController))]
public class PowerUpController : MonoBehaviour
{
    private Player.SpriteController spriteController;
    private bool hasSword;

    private void Awake()
    {
        spriteController = GetComponent<Player.SpriteController>();
    }

    public void SetSword()
    {
        spriteController.SetSword();
        hasSword = true;
    }
    
    public void RemoveSword()
    {
        spriteController.SetNormal();
        hasSword = false;
    }

    public bool HasSword()
    {
        return hasSword;
    }
}
