using System;
using System.Collections.Generic;
using UnityEngine;

namespace Box{
    public class BoxSpawnerManager : SingletonBaseClass<BoxSpawnerManager> {
        [SerializeField] private List<BoxPrefabs> boxControllerPrefabs;
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
        private void AddIntoPool(int numberOfBoxes){
            foreach(BoxPrefabs boxControllerPrefab in boxControllerPrefabs){
                foreach(BoxController boxController in boxControllerPrefab.boxControllers){
                    for (int i = 0; i < numberOfBoxes; i++)
                    {
                        BoxController newBox = Instantiate(boxController, transform);
                        newBox.gameObject.SetActive(false);
                        boxPool.Add(newBox);
                    }
                }
            }
        }

        /// <summary>
        /// Get box controller from pool or create new one
        /// </summary>
        /// <param name="position">Box position</param>
        /// <param name="boxPersonality">Box personality</param>
        /// <param name="boxDirection">Box direction</param>
        /// <returns>Box Controller</returns>
        public BoxController GetOrCreateBox(Vector2 position, 
            BoxPersonality boxPersonality, BoxDirection boxDirection){
            // Search in box pool
            BoxController boxController = boxPool.Find(box =>
                !box.gameObject.activeInHierarchy && 
                box.BoxProperties.boxPersonality == boxPersonality &&
                box.BoxProperties.boxDirection == boxDirection);

            if(boxController == null){
                // Search the same prefab
                foreach (BoxPrefabs boxControllerPrefab in boxControllerPrefabs)
                {
                    foreach (BoxController box in boxControllerPrefab.boxControllers)
                    {
                        if(box.BoxProperties.boxPersonality == boxPersonality &&
                            box.BoxProperties.boxDirection == boxDirection){
                            // Duplicate the box
                            boxController = Instantiate(box, transform);
                            boxPool.Add(boxController);

                            break;
                        }
                    }
                }
            }

            boxQueue.Enqueue(boxController);
            boxController.gameObject.SetActive(true);
            boxController.SetPosition(position);
            SetBoxOrder();
            return boxController;
        }

        /// <summary>
        /// Set box order for box controller
        /// </summary>
        private void SetBoxOrder(){
            BoxController[] boxControllers = boxQueue.ToArray();

            for (int i = 0; i < boxControllers.Length; i++){
                boxControllers[i].BoxSpriteRenderer.sortingOrder = i;
            }
        }

        /// <summary>
        /// Remove box from queue
        /// </summary>
        public void RemoveBox(){
            BoxController boxController = boxQueue.Dequeue();
            boxController.gameObject.SetActive(false);
        }
    }

    [Serializable]
    public class BoxPrefabs{
        public string name;
        public List<BoxController> boxControllers;
    }
}