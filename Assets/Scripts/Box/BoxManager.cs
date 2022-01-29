using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Box{
    public class BoxManager : SingletonBaseClass<BoxManager> {
        private BoxSpawnerManager boxSpawnerManager;
        [Range(0, 10)]
        [SerializeField] private int initialBoxToSpawn;
        [SerializeField] private float[] xAxis;

        private void Awake() {
            boxSpawnerManager = BoxSpawnerManager.Instance;
        }

        private void Start() {
            // Generate initial boxes
            for (int i = 0; i < initialBoxToSpawn; i++){
                int randomNumber = RandomNumber.GenerateRandomNumber();
                float xAxis = this.xAxis[randomNumber];
                float yAxis = i;

                MakeBox(randomNumber, xAxis, yAxis);
            }
        }

        /// <summary>
        /// Make box
        /// </summary>
        /// <param name="randomNumber"></param>
        /// <param name="xAxis"></param>
        /// <param name="yAxis"></param>
        private void MakeBox(int randomNumber, float xAxis, float yAxis){
            int randomSpriteNumber = UnityEngine.Random.Range(0, 2);

            switch(randomNumber){
                case 0: // Left
                    switch(randomSpriteNumber){
                        case 0: // Happy
                            boxSpawnerManager.GetOrCreateBox(
                                new Vector2(xAxis, yAxis),
                                BoxPersonality.Positive,
                                BoxDirection.Left
                            );
                            break;
                        case 1: // Mad
                            boxSpawnerManager.GetOrCreateBox(
                                new Vector2(xAxis, yAxis),
                                BoxPersonality.Negative,
                                BoxDirection.Left
                            );
                            break;
                    }
                    break;
                case 1: // Right
                    switch(randomSpriteNumber){
                        case 0: // Happy
                            boxSpawnerManager.GetOrCreateBox(
                                new Vector2(xAxis, yAxis),
                                BoxPersonality.Positive,
                                BoxDirection.Right
                            );
                            break;
                        case 1: // Mad
                            boxSpawnerManager.GetOrCreateBox(
                                new Vector2(xAxis, yAxis),
                                BoxPersonality.Negative,
                                BoxDirection.Right
                            );
                            break;
                    }
                    break;
            }
        }
    }
}