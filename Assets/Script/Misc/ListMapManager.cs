
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

        private GameObject CurrentMap, NextMap, PreviousMap;
        

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
            CurrentMap = GameObject.Find(GetCurrentMap(transform));
            PreviousMap = GameObject.Find(GetPreviousMap(transform));

            PreviousMap.transform.Find("BG").gameObject.SetActive(true);

            CurrentMap.transform.Find("BG").gameObject.SetActive(false);


            Transform borderRight = PreviousMap.transform.Find("BorderRight").transform;

            confiner2D.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = PreviousMap.transform.Find("BG").GetComponent<PolygonCollider2D>();
            
            player.position = borderRight.position - new Vector3(1.5f, 0.5f, 0f);

        }

        public void LoadNextMap(Transform transform)
        {
            
            CurrentMap = GameObject.Find(GetCurrentMap(transform));
            NextMap = GameObject.Find(GetNextMap(transform));

            NextMap.transform.Find("BG").gameObject.SetActive(true);

            CurrentMap.transform.Find("BG").gameObject.SetActive(false);

            Transform borderLeft = NextMap.transform.Find("BorderLeft").transform;
       
            confiner2D.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = NextMap.transform.Find("BG").GetComponent<PolygonCollider2D>();
            
            player.position = borderLeft.position + new Vector3(1.5f, 0.5f, 0f);

        }
    }
}
