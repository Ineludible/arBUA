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

    /// <summary>
    /// Uses 4 frame corner objects to visualize an AugmentedImage.
    /// </summary>
    public class AugmentedImageVisualizer : MonoBehaviour
    {
        /// <summary>
        /// The AugmentedImage to visualize.
        /// </summary>
        public AugmentedImage Image;

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

        /// Mio

        public Button b1_policien;
        public Button b2_filoletras;

        public Button b11_poli;
        public Button b12_cien;


        public Button ingen;
        public Button arte;
        public Button cons;
        public Button arqu;
        public Button info;
        public Button urb;
        public Button ingq;
        public Button ast;
        public Button pin;

        //public Button[] b111_poli = {ingen, arte, cons, arqu, info, ingq, ast, pin, urb };
        private int activo1 = 1;
        private int activo2 = 0;
        private int activo3 = 0;


        public ArrayList b111_poli = new ArrayList();

        public AugmentedImageVisualizer()
        {
            //Button[]  = { ingen, arte, cons, arqu, info, ingq, ast, pin, urb };
            b111_poli.Add(ingen);
            b111_poli.Add(arte);
            b111_poli.Add(cons);
            b111_poli.Add(arqu);
            b111_poli.Add(info);
            b111_poli.Add(ingq);
            b111_poli.Add(ast);
            b111_poli.Add(pin);
            b111_poli.Add(urb);

        }

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

        /// <summary>
        /// The Unity Update method.
        /// </summary>
        public void Update()
        {
            if (Image == null || Image.TrackingState != TrackingState.Tracking || activo1==1 || activo2 == 1 || activo3 == 1)
            {
                if (activo2 == 1)
                {

                    b1_policien.gameObject.SetActive(false);
                    b2_filoletras.gameObject.SetActive(false);
                    b11_poli.gameObject.SetActive(true);
                    b12_cien.gameObject.SetActive(true);

                    foreach (Button bt in b111_poli)
                    {
                        bt.gameObject.SetActive(false);
                    }
                }
                else if (activo3 == 1)
                {
                    b1_policien.gameObject.SetActive(false);
                    b2_filoletras.gameObject.SetActive(false);
                    b11_poli.gameObject.SetActive(false);
                    b12_cien.gameObject.SetActive(false);
                    foreach (Button bt in b111_poli)
                    {
                        bt.gameObject.SetActive(true);
                    }
                } else if (activo1 == 1)
                {
                    b1_policien.gameObject.SetActive(true);
                    b2_filoletras.gameObject.SetActive(true);
                    b11_poli.gameObject.SetActive(false);
                    b12_cien.gameObject.SetActive(false);

                    foreach (Button bt in b111_poli)
                    {
                        bt.gameObject.SetActive(false);
                    }
                }
                

                arrow1.SetActive(false);
                arrow2.SetActive(false);
                arrow3.SetActive(false);
                arrow4.SetActive(false);
                final.SetActive(false);
                return;
            }

            

            arrow1.transform.position = new Vector3(0f, 0f, 0.500f);
            arrow2.transform.position = new Vector3(0f, 0.1f, 1f);
            arrow3.transform.position = new Vector3(0f, 0.2f, 2f);
            arrow4.transform.position = new Vector3(0f, 0.3f, 3f);
            final.transform.position = new Vector3(0f, 0.4f, 4f);


            b1_policien.gameObject.SetActive(false);
            b2_filoletras.gameObject.SetActive(false);
            b11_poli.gameObject.SetActive(false);
            b12_cien.gameObject.SetActive(false);
            foreach (Button bt in b111_poli)
            {
                bt.gameObject.SetActive(false);
            }

            arrow1.SetActive(true);
            arrow2.SetActive(true);
            arrow3.SetActive(true);
            arrow4.SetActive(true);
            final.SetActive(true);
        }
    }
}
