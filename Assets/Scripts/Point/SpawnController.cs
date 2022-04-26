using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Point
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField] public UnityEvent<bool> OnActive;

        public void Despawn() 
        {
            OnActive?.Invoke(false);
        }

        public void Respawn()
        {
            OnActive?.Invoke(true);
        }
    }
}
