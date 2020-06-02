using System;
using UnityEngine;
using UniRx;
using Core.Enums;

namespace Core
{
    /// <summary>
    /// Class of model geometry object
    /// </summary>
    public class GeometryObjectModel : MonoBehaviour
    {
        /// <summary>
        /// Field which defines count of clicks
        /// </summary>
        public int ClickCount;
        /// <summary>
        /// Field which defines current color
        /// </summary>
        public Color CubeColor;
        /// <summary>
        /// Additional field which defines type of current object.
        /// I can define type of shape by using GetComponent<T>(), but it - not optimal
        /// </summary>
        public ETypeObject Type;
        
         

        // Start is called before the first frame update
        private void Start()
        {
            Observable.EveryUpdate().Subscribe(x =>
            //where + select for go
            {
                Observable.Timer(TimeSpan.FromSeconds(x));
                //change color to color from list
            }).AddTo(this);
        }
    }
}