using System.IO;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using UnityEngine;

namespace Core.IO
{
    /// <summary>
    /// Class which provides load from bundles
    /// </summary>
    public class LoadBundle : MonoBehaviour
    {
        public List<Object> lstGO { get; private set; }
        private int version = 0;
        
        public List<KeyValuePair<string, List<string>>> bundlesListNames { get; private set; }
        private DataContractJsonSerializer serializer;

        // Start is called before the first frame update
        private async void Start()
        {
            bundlesListNames = new List<KeyValuePair<string,List<string>>>();
            serializer = new DataContractJsonSerializer(typeof(List<KeyValuePair<string, List<string>>>));
            LoadData();
            lstGO = new List<Object>();

            LoadBundles();
        }

        /// <summary>
        /// This method not async
        /// </summary>
        private void LoadData()
        {
            using (var fs = new FileStream("Assets/Resources/data.json", FileMode.Open, FileAccess.Read))
            {
                bundlesListNames = serializer.ReadObject(fs) as List<KeyValuePair<string,List<string>>>;
            }
        }

        private void LoadBundles()
        {
            foreach (var ab in bundlesListNames)
            {
                var bundle = AssetBundle.LoadFromFile(Path.Combine("Assets/AssetBundles/bundles", ab.Key));
                foreach(var b in ab.Value)
                    lstGO.Add(bundle.LoadAsset(b));
            }
        
            Debug.Log(lstGO.Count);
        }


#if DEBUG
        /// <summary>
        /// Debug method for making asset bundle data
        /// </summary>
        private void DebugMakeBundleData()
        {
            var item = new KeyValuePair<string, List<string>>("fist", new List<string>());
            item.Value.Add("Bullet.prefab");
            item.Value.Add("Capsule1.prefab");
            item.Value.Add("Capsule2.prefab");
            bundlesListNames.Add((item));
            
            item = new KeyValuePair<string, List<string>>("second", new List<string>());
            item.Value.Add( "Cube1.prefab");
            item.Value.Add( "Cube2.prefab");
            item.Value.Add( "Cylinder1.prefab");
            bundlesListNames.Add(item);
            
            item = new KeyValuePair<string, List<string>>("third", new List<string>());
            item.Value.Add( "Cylinder2.prefab");
            item.Value.Add( "Rectangle.prefab");
            item.Value.Add( "Sphere.prefab");
            bundlesListNames.Add(item);

            using (var fs = new FileStream("Assets/Resources/data.json", FileMode.Create, FileAccess.Write))
                serializer.WriteObject(fs, bundlesListNames);
        }
#endif
    }
}