using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UI;
using UnityEngine;

public class SwordAbilityController : MonoBehaviour, AbilityController
{
	private static int timer;
	[SerializeField] private TimerController timerController;
	[SerializeField] private int duration;
    private GameObject[] enemies;

	private static IEnumerator AbilityEnd(int duration, 
		TimerController timerController, GameObject[] enemies, 
		GameObject player)
    {
		for (timer = duration; timer > 0; timer--)
		{
			timerController.UpdateSeconds(timer);
			yield return new WaitForSeconds(1);
		}
		timerController.EndTimer();
		foreach (var enemy in enemies)
        {
            enemy.transform.parent
				.GetComponent<Enemy.SpriteController>().SetNormal();
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
        player.GetComponent<PowerUpController>().StartCoroutine(
			AbilityEnd(duration, timerController, enemies, player));
    }

    void AbilityStart(GameObject player)
    {
        foreach (var enemy in enemies)
        {
            enemy.transform.parent
				.GetComponent<Enemy.SpriteController>().SetVunerable();
        }
        player.GetComponent<PowerUpController>().SetSword();
	}
}
