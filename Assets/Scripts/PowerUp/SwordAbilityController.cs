using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAbilityController : MonoBehaviour, AbilityController
{
    [SerializeField] private int duration;
    private GameObject[] enemies;

    private static IEnumerator AbilityEnd(int duration, GameObject[] enemies, GameObject player)
    {
        yield return new WaitForSeconds(duration);
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<Enemy.SpriteController>().SetNormal();
        }
        player.GetComponent<PowerUpController>().RemoveSword();
    }

    private void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void Ability(GameObject player)
    {
        AbilityStart(player);
        player.GetComponent<PowerUpController>().StartCoroutine(AbilityEnd(duration, enemies, player));
    }

    void AbilityStart(GameObject player)
    {
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<Enemy.SpriteController>().SetVunerable();
        }
        player.GetComponent<PowerUpController>().SetSword();
    }
}
