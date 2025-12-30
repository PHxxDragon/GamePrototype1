using System.Collections.Generic;
using GameObjects.Squares;
using GameObjects.Targets;
using UnityEngine;

namespace GameManagers
{
    public class GameManager : MonoBehaviour
    {
        public readonly List<SquareController> SquareComponents = new();
        public readonly List<TargetController> TargetComponents = new();
    }
}
