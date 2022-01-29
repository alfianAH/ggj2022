using UnityEngine;

namespace Utils
{
    public static class RandomNumber
    {
        private static int previousRandomNumber = -1;
        private static readonly int limitSameBox = 2;
        private static int sameBoxNumber;

        /// <summary>
        /// Generate Random number for box with limit 
        /// </summary>
        /// <returns>Random number between 0-1</returns>
        public static int GenerateRandomNumber()
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