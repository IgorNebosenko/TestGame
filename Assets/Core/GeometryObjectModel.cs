using System;
using System.Threading;
using System.Threading.Tasks;
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
            GameDataProvider gdp = GameObject.Find("GO").GetComponent<GameDataProvider>();
            CubeColor = gdp.GetColor(Type, ClickCount);
            gameObject.GetComponent<MeshRenderer>().material.color = CubeColor;
            
           Observable.Interval(TimeSpan.FromSeconds(gdp.Delay)).Subscribe( x =>
            {
                CubeColor = gdp.GetColor(Type, ClickCount);
                gameObject.GetComponent<MeshRenderer>().material.color = CubeColor;

            }).AddTo(this);
        }
    }
}