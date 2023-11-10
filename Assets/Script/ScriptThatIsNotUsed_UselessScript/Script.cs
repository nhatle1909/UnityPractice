//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.Tilemaps;

//namespace Assets
//{
//    public class MiscControllers : MonoBehaviour
//    {
//        private static MiscControllers instance;

//        public static MiscControllers Instance
//        {
//            get
//            {
//                if (instance == null)
//                {
//                    instance = new MiscControllers();
//                }

//                return instance;
//            }
//        }


//        private void Awake()
//        {
//            if (instance != null && instance != this)
//            {
//                Destroy(this);
//            }
//        }


   

     

//        //public bool isGrounded(Transform character)
//        //{
//        //    var isGround = false;
//        //    RaycastHit2D hit = Physics2D.Raycast(character.position, Vector2.down, 1f);
//        //    if (hit.collider != null)
//        //    {
//        //        isGround = true;
//        //    }
//        //    else
//        //    {
//        //        isGround = false;
//        //    }
//        //    return isGround;

//        //}
//    }
//}