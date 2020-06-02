using System;
using System.Collections;
using System.Collections.Generic;
using Core.Enums;
using UnityEngine;
using Resources;

namespace Core
{
    /// <summary>
    /// Provides work with GameData
    /// </summary>
    public class GameDataProvider : MonoBehaviour
    {
        private GameData gd;

        private void Start()
        {
            gd = ScriptableObject.CreateInstance<GameData>();
            gd.MakeRndColors();
        }

        public Color GetColor(ETypeObject type, int clicks)
        {
            return gd.GetColor(type, clicks);
        }

        public int Delay => gd.delayTime;
    }
}