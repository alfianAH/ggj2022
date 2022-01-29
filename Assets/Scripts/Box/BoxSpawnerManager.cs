using System.Collections.Generic;
using UnityEngine;

namespace Box{
    public class BoxSpawnerManager : SingletonBaseClass<BoxSpawnerManager> {
        [SerializeField] private BoxController boxControllerPrefab;
        [Range(0, 10)]
        [SerializeField] private int initialBoxes;

        private List<BoxController> boxPool;
        private Queue<BoxController> boxQueue;

        private void Awake() {
            boxPool = new List<BoxController>();
            boxQueue = new Queue<BoxController>();

            AddIntoPool(initialBoxes);
        }
        
        /// <summary>
        /// Create number of boxes
        /// </summary>
        /// <param name="numberOfBoxes">Number of boxes</param>
        /// <param name="setActive">Box's active property</param>
        private void AddIntoPool(int numberOfBoxes){
            for (int i = 0; i < numberOfBoxes; i++){
                BoxController boxController = Instantiate(boxControllerPrefab, transform);
                boxController.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Get box controller from pool or create new one
        /// </summary>
        /// <param name="position">Box position</param>
        /// <returns>Box Controller</returns>
        public BoxController GetOrCreateBox(Vector2 position){
            BoxController boxController = boxPool.Find(box =>
                !box.gameObject.activeInHierarchy);

            if(boxController == null){
                boxController = Instantiate(boxControllerPrefab, transform);
                boxPool.Add(boxController);
            }
            boxQueue.Enqueue(boxController);
            boxController.gameObject.SetActive(true);
            boxController.SetPosition(position);
            return boxController;
        }

        /// <summary>
        /// Remove box from queue
        /// </summary>
        public void RemoveBox(){
            BoxController boxController = boxQueue.Dequeue();
            boxController.gameObject.SetActive(false);
        }
    }
}