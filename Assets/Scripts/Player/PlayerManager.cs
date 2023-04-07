using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBestCourse
{
    public class PlayerManager : CharacterManager
    {
        PlayerLocomotionManager playerLocomotionManager;

        protected override void Awake()
        {
            base.Awake();

            // do more stuff, only for the player

            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
        }

        protected override void Update()
        {
            base.Update();

            // handle movement
            playerLocomotionManager.HandleAllMovement();
        }
    }
}

