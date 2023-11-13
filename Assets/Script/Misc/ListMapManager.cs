
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;
using Cinemachine;

namespace Assets
{
    public class ListMapManager 
    {
        private ListMapManager() { }
        private static ListMapManager instance;
        public static ListMapManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ListMapManager();
                }

                return instance;
            }
        }

        List<string> listMaps = new List<string>()
        {
             { "Village Backside" },
             { "AstalVillage"}
        };
        private Transform player = GameObject.Find("Player").transform;

        private GameObject confiner2D = GameObject.Find("Virtual Camera");

        private Transform CurrentMap, NewMap;
        Transform borderLeft, borderRight;

        public string GetPreviousMap(Transform transform)
        {
            int previousMapIndex = listMaps.IndexOf(transform.parent.name) - 1;
           
            return listMaps[previousMapIndex];          
        }
        public string GetNextMap(Transform transform)
        {
            int nextMapIndex = listMaps.IndexOf(transform.parent.name) + 1;

            return listMaps[nextMapIndex];
        }

        public string GetCurrentMap(Transform transform)
        {
            int currentMapIndex = listMaps.IndexOf(transform.parent.name);
            return listMaps[currentMapIndex];
        }

        public void LoadPreviousMap(Transform transform)
        {
            CurrentMap = GameObject.Find(GetCurrentMap(transform)).transform; // Get Current Map's Transform
            NewMap = GameObject.Find(GetPreviousMap(transform)).transform; // Get NewMap ( Previous Map ) 's Transforms

            NewMap.Find("BG").gameObject.SetActive(true); // Active Background ( BG ) game object of New Map

            CurrentMap.Find("BG").gameObject.SetActive(false); // Deactive BG gameobject of Current Map

            borderRight = NewMap.Find("BorderRight").transform; // Find Border Right of New Map

            confiner2D.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = NewMap.Find("BG").GetComponent<PolygonCollider2D>(); // Change Bounding Shape of Cinemachine Virtual Camera to Polygon Collider of BG of New Map
            
            player.position = borderRight.position - new Vector3(1.5f, 0.5f, 0f); // Teleport Player

        }

        public void LoadNextMap(Transform transform)
        {
            
            CurrentMap = GameObject.Find(GetCurrentMap(transform)).transform; // Get Current Map's Transform
            NewMap = GameObject.Find(GetNextMap(transform)).transform; // Get NewMap ( Next Map ) 's Transforms

            NewMap.Find("BG").gameObject.SetActive(true); // Active Background ( BG ) game object of New Map

            CurrentMap.Find("BG").gameObject.SetActive(false); // Deactive BG gameobject of Current Map

            borderLeft = NewMap.Find("BorderLeft").transform; // Find Border Left of New Map

            confiner2D.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = NewMap.Find("BG").GetComponent<PolygonCollider2D>(); // Change Bounding Shape of Cinemachine Virtual Camera to Polygon Collider of BG of New Map

            player.position = borderLeft.position + new Vector3(1.5f, 0.5f, 0f); // Teleport Player

        }
    }
}
