using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Box
{
    public class UltimateBox : SingletonBaseClass<UltimateBox>
    {
        [Range(0, 20)]
        [SerializeField] private float ultiDuration = 10f;
        [SerializeField] private float requestedPower = 20;
        [SerializeField] private float currentPower;
        
        [SerializeField] private Slider power;
        [SerializeField] private Button ultiButton;

        private bool ultiOnGoing;

        public bool UltiOnGoing => ultiOnGoing;

        // Start is called before the first frame update
        private void Start()
        {
            currentPower = 0;
        }

        // Update is called once per frame
        private void Update()
        {
            power.value = currentPower / requestedPower;

            if(power.value >= 1f){
                ultiButton.interactable = true;
            } else{
                ultiButton.interactable = false;
            }
        }

        /// <summary>
        /// add Power smoothly
        /// </summary>
        /// <param name="power">adding power</param>
        public void AddPower(float power)
        {
            if(ultiOnGoing) return;

            if(currentPower >= requestedPower) {
                currentPower = requestedPower;
                return;
            }
            StartCoroutine(IncreasePower(power));
        }

        private IEnumerator IncreasePower(float power)
        {
            float goal = currentPower + power;
            float t = 0;
            while (currentPower < goal)
            {
                currentPower = Mathf.MoveTowards(currentPower, goal, t);
                t += Time.deltaTime;

                if(currentPower >= requestedPower) {
                    currentPower = requestedPower;
                    yield break;
                }
                yield return null;
            }
        }

        private IEnumerator DecreasePower(float power)
        {
            float goal = currentPower + power;
            float t = 0;
            while (currentPower > goal)
            {
                currentPower = Mathf.MoveTowards(currentPower, goal, t);
                t += Time.deltaTime;
                yield return null;
            }
        }

        public IEnumerator StartUltimate(){
            ultiOnGoing = true;

            while(currentPower != 0){
                currentPower -= ultiDuration / requestedPower;
                yield return new WaitForSeconds(0.3f);
            }

            ultiOnGoing = false;
        }
    }
}