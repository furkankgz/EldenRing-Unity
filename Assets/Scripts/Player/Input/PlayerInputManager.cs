using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyBestCourse
{
    public class PlayerInputManager : MonoBehaviour
    {
        public static PlayerInputManager instance;
        //Think about goals in steps
        // 1. find a way to read the values of a joy stick
        // 2. move character based on those values

        PlayerControls playerControls;
        [SerializeField] Vector2 movementInput;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);

            // when we scene changes, run the logic 
            SceneManager.activeSceneChanged += OnSceneChange;

            instance.enabled = false;
        }

        private void OnSceneChange(Scene oldScene, Scene newScene)
        {
            // if we are loading into our world scene, enable our player controls
            if (newScene.buildIndex == WorldSaveGameManager.instance.GetWorldSceneIndex())
            {
                instance.enabled = true;
            }
            // otherwise we must be at the main menu, disable our players controls
            // this is so our player cant move around if we enter things like a character creation menu ect 
            else
            {
                instance.enabled = false;
            }
        }

        private void OnEnable()
        {
            if (playerControls == null)
            {
                playerControls = new PlayerControls();
                playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            }

            playerControls.Enable();
        }

        private void OnDestroy()
        {
            //if we destroy this object, unscribe from this event
            SceneManager.activeSceneChanged -= OnSceneChange;
        }

    }
}

