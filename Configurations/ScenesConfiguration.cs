using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace StonedFox.Configurations
{
    [CreateAssetMenu(fileName = "ScenesConfiguration", menuName = "Ship Project/Scenes Configuration")]
    public class ScenesConfiguration : ScriptableObject
    {
        public ScenePicker[] scenes;

        public const string Scenes = "scenes";
    }

    [Serializable]
    public class ScenePicker
    {
        public string scenePath;

        public const string ScenePath = "scenePath";
    }
}
