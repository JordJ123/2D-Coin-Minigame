using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionAbilityController : MonoBehaviour, AbilityController
{
    public void Ability(GameObject player)
    {
        player.GetComponent<PowerUpController>().SetLivesPotion();
    }
}
