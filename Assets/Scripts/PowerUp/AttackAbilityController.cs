using System.Collections;
using UnityEngine;

namespace PowerUp
{
	public class AttackAbilityController : TimedAbilityController
	{
		private int id;
		private GameObject[] enemies;
    
    	private void Awake()
		{
			enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }
    
		public override void Ability(GameObject player)
		{
			AbilityStart(player);
			player.GetComponent<PowerUpController>()
				.StartCoroutine(AbilityEnd(player));
		}
    
        protected override void AbilityStart(GameObject player)
        {
			foreach (var enemy in enemies)
            {
                enemy.GetComponent<Enemy.SpriteController>().SetVunerable();
            }
			player.GetComponent<PowerUpController>().SetAttackPowerUp(this);
		}
    	
    	protected override IEnumerator AbilityEnd(GameObject player)
    	{
			for (currentDuration = duration; currentDuration > 0; 
				currentDuration--)
    		{
				InvokeOnSecondEvent(currentDuration);
				yield return new WaitForSeconds(1);
    		}
			InvokeOnSecondEvent(0);
			foreach (var enemy in enemies)
			{
				enemy.GetComponent<Enemy.SpriteController>().SetInvunerable();
			}
			player.GetComponent<PowerUpController>().RemovePowerUp();
		}
    }
}
