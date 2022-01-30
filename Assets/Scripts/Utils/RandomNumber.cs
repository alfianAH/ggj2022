using UnityEngine;

namespace Utils
{
    public class RandomNumber
    {
        private int previousRandomNumber = -1;
        private readonly int limitSameBox = 2;
        private int sameBoxNumber = 0;

        /// <summary>
        /// Generate Random number for box with limit 
        /// </summary>
        /// <returns>Random number between 0-1</returns>
        public int GenerateRandomNumber()
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