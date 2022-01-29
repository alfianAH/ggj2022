using UnityEngine;

namespace Box{
    public class BoxManager : SingletonBaseClass<BoxManager> {
        [Range(0, 10)]
        [SerializeField] private int initialBoxToSpawn;

        private BoxSpawnerManager boxSpawnerManager;

        private int previousRandomNumber = -1;
        private readonly int limitSameBox = 3;
        private int sameBoxNumber = 0;

        private void Awake() {
            boxSpawnerManager = BoxSpawnerManager.Instance;
        }

        private void Start() {
            // Generate initial boxes
            for (int i = 0; i < initialBoxToSpawn; i++){
                int randomNumber = GenerateRandomNumber();
                float yAxis = i;

                MakeBox(randomNumber, 0, yAxis);
            }
        }

        /// <summary>
        /// Make box
        /// </summary>
        /// <param name="randomPersonalityNumber"></param>
        /// <param name="xAxis"></param>
        /// <param name="yAxis"></param>
        private void MakeBox(int randomPersonalityNumber, float xAxis, float yAxis){
            int randomSpriteNumber = Random.Range(0, 2);

            switch(randomPersonalityNumber){
                case 0: // Happy
                    switch(randomSpriteNumber){
                        case 0: // Left
                            boxSpawnerManager.GetOrCreateBox(
                                new Vector2(xAxis, yAxis),
                                BoxPersonality.Positive,
                                BoxDirection.Left
                            );
                            break;
                        case 1: // Right
                            boxSpawnerManager.GetOrCreateBox(
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
                            boxSpawnerManager.GetOrCreateBox(
                                new Vector2(xAxis, yAxis),
                                BoxPersonality.Negative,
                                BoxDirection.Right
                            );
                            break;
                        case 1: // Right
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

        /// <summary>
        /// Remove box from queue
        /// </summary>
        public void RemoveBox(){
            BoxController boxController = boxSpawnerManager.BoxQueue.Dequeue();
            boxController.gameObject.SetActive(false);
            int randomNumber = GenerateRandomNumber();
            float yAxis = 6;

            MakeBox(randomNumber, 0, yAxis);
        }

        /// <summary>
        /// Generate Random number for box with limit 
        /// </summary>
        /// <returns>Random number between 0-1</returns>
        private int GenerateRandomNumber()
        {
            int randomNumber = Random.Range(0, 2);
            
            if (previousRandomNumber == randomNumber)
            {
                sameBoxNumber++;

                // If same box number reach limit, ...
                if (sameBoxNumber == limitSameBox)
                {
                    while (previousRandomNumber == randomNumber)
                    {
                        randomNumber = Random.Range(0, 2);
                    }
                    previousRandomNumber = randomNumber;
                    sameBoxNumber = 0;
                }
            }
            else
            {
                sameBoxNumber = 0;
                previousRandomNumber = randomNumber;
            }

            return randomNumber;
        }
    }
}