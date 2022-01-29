using Box;

namespace Gameplay
{
    public class GameplayManager : SingletonBaseClass<GameplayManager>
    {
        public BoxPersonality chosenBoxPersonality;

        public void ChooseBoxPersonality(BoxPersonality boxPersonality){
            chosenBoxPersonality = boxPersonality;
        }
    }
}