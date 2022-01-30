using UnityEngine;
using Utils;

namespace Box{
    public class BoxManager : SingletonBaseClass<BoxManager> {
        [Range(0, 10)]
        [SerializeField] private int initialBoxToSpawn;

        private BoxBarMeterManager boxBarMeterManager;
        private BoxSpawnerManager boxSpawnerManager;
        private RandomNumber directionRandomNumber, personalityRandomNumber;

        private void Awake() {
            boxBarMeterManager = BoxBarMeterManager.Instance;
            boxSpawnerManager = BoxSpawnerManager.Instance;
            directionRandomNumber = new RandomNumber();
            personalityRandomNumber = new RandomNumber();
        }

        private void Start() {
            // Generate initial boxes
            for (int i = 0; i < initialBoxToSpawn; i++){
                GenerateRandomBox(i);
            }
        }

        private void GenerateRandomBox(float yAxis){
            int randomNumber = personalityRandomNumber.GenerateRandomNumber();
            MakeBox(randomNumber, 0, yAxis);
        }

        /// <summary>
        /// Make box
        /// </summary>
        /// <param name="randomPersonalityNumber"></param>
        /// <param name="xAxis"></param>
        /// <param name="yAxis"></param>
        private void MakeBox(int randomPersonalityNumber, float xAxis, float yAxis){
            int randomSpriteNumber = directionRandomNumber.GenerateRandomNumber();
            BoxController boxController = null;

            switch(randomPersonalityNumber){
                case 0: // Happy
                    switch(randomSpriteNumber){
                        case 0: // Left
                            boxController = boxSpawnerManager.GetOrCreateBox(
                                new Vector2(xAxis, yAxis),
                                BoxPersonality.Positive,
                                BoxDirection.Left
                            );
                            break;
                        case 1: // Right
                            boxController = boxSpawnerManager.GetOrCreateBox(
                                new Vector2(xAxis, yAxis),
                                BoxPersonality.Positive,
                                BoxDirection.Left
                            );
                            break;
                    }
                    break;
                case 1: // Mad
                    switch(randomSpriteNumber){
                        case 0: // Left
                            boxController = boxSpawnerManager.GetOrCreateBox(
                                new Vector2(xAxis, yAxis),
                                BoxPersonality.Negative,
                                BoxDirection.Right
                            );
                            break;
                        case 1: // Right
                            boxController = boxSpawnerManager.GetOrCreateBox(
                                new Vector2(xAxis, yAxis),
                                BoxPersonality.Negative,
                                BoxDirection.Right
                            );
                            break;
                    }
                    break;
            }

            if(boxController != null){
                BoxBarMeter boxBarMeter = boxBarMeterManager.GetOrCreateBarMeter(boxController);
                boxBarMeter.gameObject.SetActive(true);
                boxController.BoxProperties.boxBarMeter = boxBarMeter;
            }
            else
                Debug.LogError("Box controller null. Can't get bar meter");
        }

        /// <summary>
        /// Remove box from queue
        /// </summary>
        public void RemoveBox(){
            BoxController boxController = boxSpawnerManager.BoxQueue.Dequeue();
            boxController.BoxProperties.boxBarMeter.gameObject.SetActive(false);
            boxController.BoxProperties.boxBarMeter = null;
            Destroy(boxController.gameObject);
            GenerateRandomBox(6);
        }
    }
}