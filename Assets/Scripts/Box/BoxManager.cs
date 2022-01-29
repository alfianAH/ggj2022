using UnityEngine;

namespace Box{
    public class BoxManager : SingletonBaseClass<BoxManager> {
        private BoxSpawnerManager boxSpawnerManager;
        [Range(0, 10)]
        [SerializeField] private int initialBoxToSpawn;
        [SerializeField] private int sameBoxNumber;
        [SerializeField] private float[] xAxis;

        private int previouseRandomNumber = -1;
        private readonly int limitSameBox = 2;

        private void Awake() {
            boxSpawnerManager = BoxSpawnerManager.Instance;
        }

        private void Start() {
            // Generate initial boxes
            for (int i = 0; i < initialBoxToSpawn; i++){
                float xAxis = this.xAxis[RandomNumber()];
                float yAxis = i;

                MakeBox(xAxis, yAxis);
            }
        }

        /// <summary>
        /// Make box
        /// </summary>
        /// <param name="xAxis"></param>
        /// <param name="yAxis"></param>
        private void MakeBox(float xAxis, float yAxis){
            boxSpawnerManager.GetOrCreateBox(new Vector2(xAxis, yAxis));
        }

        /// <summary>
        /// Generate Random number for box with limit 
        /// </summary>
        /// <returns>Random number between 0-1</returns>
        private int RandomNumber(){
            int randomNumber = Random.Range(0, 2);
                
            if(previouseRandomNumber == randomNumber){
                sameBoxNumber++;

                // If same box number reach limit, ...
                if(sameBoxNumber == limitSameBox){
                    while(previouseRandomNumber == randomNumber){
                        randomNumber = Random.Range(0, 2);
                    }
                }
            } else{
                sameBoxNumber = 0;
                previouseRandomNumber = randomNumber;
            }

            return randomNumber;
        }
    }
}