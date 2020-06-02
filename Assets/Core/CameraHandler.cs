using System.Collections;
using System.Collections.Generic;
using Core.IO;
using JetBrains.Annotations;
using UnityEngine;

namespace Core
{
    /// <summary>
    /// Camera handler. This class spawns objects and increments them count
    /// </summary>
    [RequireComponent(typeof(Camera))]
    public class CameraHandler : MonoBehaviour
    {
        public Transform item;
        public LoadBundle refLoadBundle;
        
        private Camera cam;
        private RaycastHit hit;
        private Ray ray;
        private bool isPressed;

        private void Start()
        {
            cam = gameObject.GetComponent<Camera>();
            if(cam == null)
                Debug.LogError("Can't find camera on GO!");
        }

        // Update is called once per frame
        private void Update()
        {
            if (!Input.GetMouseButton(0))
            {
                isPressed = false;
                return;
            }

            if (!isPressed)
            {
                ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    switch (hit.transform.tag)
                    {
                        case "Terrain":
                            var rnd = new System.Random();
                            int i;

                            Object obj = null;
                            while (obj == null)
                            {
                                i = rnd.Next(0, refLoadBundle.lstGO.Count - 1);
                                obj = refLoadBundle.lstGO[i];
                            }

                            GameObject.Instantiate(obj,
                                hit.point, Random.rotation);
                            break;
                        case "GeometryObject":
                            ++hit.transform.gameObject.GetComponent<GeometryObjectModel>().ClickCount;
                            break;
                        default:
                            Debug.LogError("Incorrect tag on clicked object!");
                            break;
                    }
                }

                isPressed = true;
            }
        }
    }
}