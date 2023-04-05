using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace MyBestCourse
{
    public class TitleScreenManager : MonoBehaviour
    {
        public void StartNetworkAsHost()
        {
            NetworkManager.Singleton.StartHost();
        }

        public void StartNewGame()
        {
            StartCoroutine(WorldSaveGameManager.instance.LoadNewGame());
        }
    }
}

