using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyBestCourse
{
    public class CharacterManager : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}

