﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
  
        public class LoadNextSceneScript : MonoBehaviour
        {
            public void OnCollisionEnter2D(Collision2D collision)
            {
                ListSceneManager.Instance.LoadNextScene();
            }
        }
    
}
