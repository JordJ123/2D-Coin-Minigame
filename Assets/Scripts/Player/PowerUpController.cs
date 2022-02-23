using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player.SpriteController))]
public class PowerUpController : MonoBehaviour
{
    private LivesController livesController;
    private Player.SpriteController spriteController;
    private bool hasSword;

    private void Awake()
    {
        livesController = GetComponent<LivesController>();
        spriteController = GetComponent<Player.SpriteController>();
    }

    public void SetSword()
    {
        spriteController.SetSword();
        hasSword = true;
    }

    public void SetLivesPotion()
    {
        livesController.GainLife();
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
