using System.Collections.Generic;
using UnityEngine;

namespace Box
{
    public class BoxBarMeterManager : SingletonBaseClass<BoxBarMeterManager>
    {
        [SerializeField] private BoxBarMeter boxBarMeterPrefab;
        private List<BoxBarMeter> boxBarMeterPool;

        private void Awake() {
            boxBarMeterPool = new List<BoxBarMeter>();
        }

        public BoxBarMeter GetOrCreateBarMeter(BoxController boxController){
            BoxBarMeter boxBarMeter = boxBarMeterPool.Find(barMeter => !barMeter.gameObject.activeInHierarchy);

            if(boxBarMeter == null){
                boxBarMeter = Instantiate(boxBarMeterPrefab, transform);
                boxBarMeterPool.Add(boxBarMeter);
            }

            boxBarMeter.boxController = boxController;
            boxBarMeter.gameObject.SetActive(false);
            return boxBarMeter;
        }
    }
}