using System;

namespace Box{
    [Serializable]
    public class BoxProperties{
        public BoxDuality boxPersonality = BoxDuality.Positive;
        public float personalityBar;
    }

    public enum BoxDuality{
        Positive, Negative
    }
}