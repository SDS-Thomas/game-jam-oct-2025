using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// DeathZone components mark a collider which will schedule a
    /// PlayerEnteredDeathZone event when the player enters the trigger.
    /// </summary>
    public class DeathZone : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (gameObject.tag != "Attack" && p != null)
            {
                var ev = Schedule<PlayerEnteredDeathZone>();
                ev.deathzone = this;
            }

            var enemy = collider.gameObject.GetComponent<EnemyController>();
            if (enemy != null)
            {
                Schedule<EnemyDeath>().enemy = enemy;
            }
        }
    }
}