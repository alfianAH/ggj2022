using System;
using UnityEngine;

namespace Box{
    [Serializable]
    public class BoxProperties{
        public BoxPersonality boxPersonality = BoxPersonality.Positive;
        public BoxDirection boxDirection = BoxDirection.Left;
        public float personalityBar;
        public Sprite oppositeSprite;
    }

    public enum BoxPersonality{
        Positive, Negative
    }

    public enum BoxDirection{
        Left, Right
    }
}