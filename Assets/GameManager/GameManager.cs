using System.Collections.Generic;
using GameObjects.Square;
using GameObjects.Target;
using UnityEngine;

namespace GameManager
{
    public class GameManager
    {
        public readonly List<SquareController> SquareComponents = new();
        public readonly List<TargetController> TargetComponents = new();
    }
}
