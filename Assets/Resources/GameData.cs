using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Core.Enums;

using System.Runtime.Serialization.Json;
using Random = UnityEngine.Random;

namespace Resources
{
    public class GameData : ScriptableObject
    {
        /// <summary>
        /// Time between change colors
        /// </summary>
        public int delayTime = 3;
        private List<ClickColorData> ClicksData;

        public GameData()
        {
            ClicksData = new List<ClickColorData>();
        }
        /// <summary>
        /// Method of making random colors
        /// </summary>
        public void MakeRndColors()
        {
            CreateByTypeRndColor(ETypeObject.Cube);
            CreateByTypeRndColor(ETypeObject.Rectangle);
            CreateByTypeRndColor(ETypeObject.Sphere);
            CreateByTypeRndColor(ETypeObject.Bullet);
            CreateByTypeRndColor(ETypeObject.Capsule);
            CreateByTypeRndColor(ETypeObject.Cylinder);
        }

        private void CreateByTypeRndColor(ETypeObject type)
        {
            System.Random rnd = new System.Random();
            int val = rnd.Next(5, 20);
            for(var i = 0; i < val; ++i)
                ClicksData.Add(new ClickColorData(type, 0,10, Random.ColorHSV()));
            val = rnd.Next(5, 20);
            for(var i = 0; i < val; ++i)
                ClicksData.Add(new ClickColorData(type, 10,20, Random.ColorHSV()));
            val = rnd.Next(5, 20);
            for(var i = 0; i < val; ++i)
                ClicksData.Add(new ClickColorData(type, 20,30, Random.ColorHSV()));
            val = rnd.Next(5, 20);
            for(var i = 0; i < val; ++i)
                ClicksData.Add(new ClickColorData(type, 30,40, Random.ColorHSV()));
            val = rnd.Next(5, 20);
            for(var i = 0; i < val; ++i)
                ClicksData.Add(new ClickColorData(type, 40,50, Random.ColorHSV()));
            val = rnd.Next(5, 20);
            for(var i = 0; i < val; ++i)
                ClicksData.Add(new ClickColorData(type, 50,75, Random.ColorHSV()));
            val = rnd.Next(5, 20);
            for(var i = 0; i < val; ++i)
                ClicksData.Add(new ClickColorData(type, 75,100, Random.ColorHSV()));
            val = rnd.Next(5, 20);
            for(var i = 0; i < val; ++i)
                ClicksData.Add(new ClickColorData(type, 100,150, Random.ColorHSV()));
            val = rnd.Next(5, 20);
            for(var i = 0; i < val; ++i)
                ClicksData.Add(new ClickColorData(type, 150,200, Random.ColorHSV()));
            val = rnd.Next(5, 20);
            for(var i = 0; i < val; ++i)
                ClicksData.Add(new ClickColorData(type, 200,300, Random.ColorHSV()));
            val = rnd.Next(5, 20);
            for(var i = 0; i < val; ++i)
                ClicksData.Add(new ClickColorData(type, 300,500, Random.ColorHSV()));
            val = rnd.Next(5, 20);
            for(var i = 0; i < val; ++i)
                ClicksData.Add(new ClickColorData(type, 500,1000, Random.ColorHSV()));
            val = rnd.Next(5, 20);
            for(var i = 0; i < val; ++i)
                ClicksData.Add(new ClickColorData(type, 1000,int.MaxValue, Random.ColorHSV()));
        }

        /// <summary>
        /// Error color for error types & error clicks count
        /// </summary>
        private static readonly Color ERROR_COLOR = new Color(255, 0,255);

        public Color GetColor(ETypeObject type, int clicks)
        {
            if (clicks < 0)
                return ERROR_COLOR;

            var res = from ccd in ClicksData
                where ccd.ObjectType == type &&
                      ccd.MinClicksCount <= clicks &&
                      ccd.MaxClicksCount > clicks
                select ccd;
            var selectedItems = new List<ClickColorData>(res);

            if (selectedItems.Count == 0)
                return ERROR_COLOR;
            if (selectedItems.Count == 1)
                return selectedItems[0].ColorObject;
            
            System.Random rnd = new System.Random();
            return selectedItems[rnd.Next(0, selectedItems.Count)].ColorObject;

        }
    }
}