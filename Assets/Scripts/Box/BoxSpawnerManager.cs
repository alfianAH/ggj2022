using System.Collections.Generic;
using UnityEngine;

namespace Box{
    public class BoxSpawnerManager : SingletonBaseClass<BoxSpawnerManager> {
        [SerializeField] private BoxController boxControllerPrefab;
        [Range(0, 10)]
        [SerializeField] private int initialBoxes;
        [Range(0, 10)]
        [SerializeField] private int spareBoxes;

        private List<BoxController> boxPool;
        private Queue<BoxController> boxQueue;

        private void Awake() {
            boxPool = new List<BoxController>();
            boxQueue = new Queue<BoxController>();

            CreateBoxes(initialBoxes, true);
            CreateBoxes(spareBoxes, false);
        }
        
        /// <summary>
        /// Create number of boxes
        /// </summary>
        /// <param name="numberOfBoxes">Number of boxes</param>
        /// <param name="setActive">Box's active property</param>
        private void CreateBoxes(int numberOfBoxes, bool setActive){
            for (int i = 0; i < numberOfBoxes; i++){
                BoxController boxController = Instantiate(boxControllerPrefab, transform);
                boxController.gameObject.SetActive(setActive);
                if(setActive)
                    boxQueue.Enqueue(boxController);
            }
        }

        /// <summary>
        /// Get box controller from pool or create new one
        /// </summary>
        /// <returns>Box Controller</returns>
        private BoxController GetOrCreateBox(){
            BoxController boxController = boxPool.Find(box =>
                !box.gameObject.activeInHierarchy);

            if(boxController == null){
                boxController = Instantiate(boxControllerPrefab, transform);
                boxPool.Add(boxController);
            }

            boxController.gameObject.SetActive(false);
            return boxController;
        }
    }
}