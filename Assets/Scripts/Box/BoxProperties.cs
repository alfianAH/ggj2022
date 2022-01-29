using System;
using System.Collections.Generic;
using UnityEngine;

namespace Box{
    [Serializable]
    public class BoxProperties{
        public BoxPersonality boxPersonality = BoxPersonality.Positive;
        public BoxDirection boxDirection = BoxDirection.Left;
        public List<BoxSprite> boxSprites;
    }

    [Serializable]
    public class BoxSprite{
        public BoxPersonality boxPersonality;
        public Sprite personalitySprite;
    }

    public enum BoxPersonality{
        Positive, Negative
    }

    public enum BoxDirection{
        Left, Right
    }
}