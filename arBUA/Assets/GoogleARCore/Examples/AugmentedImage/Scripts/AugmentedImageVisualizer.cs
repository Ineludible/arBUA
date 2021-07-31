//-----------------------------------------------------------------------
// <copyright file="AugmentedImageVisualizer.cs" company="Google LLC">
//
// Copyright 2018 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleARCore.Examples.AugmentedImage
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using GoogleARCoreInternal;
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using UnityEngine.SceneManagement;

    /// <summary>
    /// Uses 4 frame corner objects to visualize an AugmentedImage.
    /// </summary>
    public class AugmentedImageVisualizer : MonoBehaviour
    {
        /// <summary>
        /// The AugmentedImage to visualize.
        /// </summary>
        public AugmentedImage Image;

        public GameObject RA;

        /// <summary>
        /// A model for the lower left corner of the frame to place when an image is detected.
        /// </summary>
        public GameObject arrow1;

        /// <summary>
        /// A model for the lower right corner of the frame to place when an image is detected.
        /// </summary>
        public GameObject arrow2;

        /// <summary>
        /// A model for the upper left corner of the frame to place when an image is detected.
        /// </summary>
        public GameObject arrow3;

        /// <summary>
        /// A model for the upper right corner of the frame to place when an image is detected.
        /// </summary>
        public GameObject arrow4;

        public GameObject final;

        //Pantallas menu navegacion
        public Canvas screen1;
        public Canvas screen2;
        public Canvas screen3;
        public Canvas UI;


        private int activo1 = 1;
        private int activo2 = 0;
        private int activo3 = 0;

        public void activar1()
        {
            activo1 = 0;
            activo2 = 1;
            activo3 = 0;
        }

        public void activar2()
        {
            activo1 = 0;
            activo2 = 0;
            activo3 = 1;
        }


        public void activar3()
        {
            activo1 = 0;
            activo2 = 0;
            activo3 = 0;
        }

        public void volver()
        {
            activo1 = 1;
            activo2 = 0;
            activo3 = 0;
        }



        /// <summary>
        /// The Unity Update method.
        /// </summary>
        public void Update()
        {

            //Si no se ha escaneado la imagen todavia o no se ha activado la realidad aumentada
            //deben permanecer ocultos los objetos 3d del camino
            if (Image == null || Image.TrackingState != TrackingState.Tracking || activo1==1 || activo2==1 || activo3==1)
            {
                if (activo1 == 1)
                {
                    screen1.gameObject.SetActive(true);
                    screen2.gameObject.SetActive(false);
                    screen3.gameObject.SetActive(false);
                } else if (activo2 == 1)
                {
                    screen1.gameObject.SetActive(false);
                    screen2.gameObject.SetActive(true);
                    screen3.gameObject.SetActive(false);
                } else if(activo3 == 1)
                {
                    screen1.gameObject.SetActive(false);
                    screen2.gameObject.SetActive(false);
                    screen3.gameObject.SetActive(true);
                }

                RA.SetActive(false);
                UI.gameObject.SetActive(false);
                return;
            } 
                arrow1.transform.position = new Vector3(0f, 0f, 0.500f);
                arrow2.transform.position = new Vector3(0f, 0.1f, 1f);
                arrow3.transform.position = new Vector3(0f, 0.2f, 2f);
                arrow4.transform.position = new Vector3(0f, 0.3f, 3f);
                final.transform.position = new Vector3(0f, 0.4f, 4f);

                UI.gameObject.SetActive(true);
                RA.SetActive(true);
                screen1.gameObject.SetActive(false);
                screen2.gameObject.SetActive(false);
                screen3.gameObject.SetActive(false);

        }
    }
}
