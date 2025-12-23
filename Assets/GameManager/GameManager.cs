using System.Collections.Generic;
using Objects.Square;
using Objects.Target;
using UnityEngine;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        public readonly List<SquareController> SquareComponents = new();
        public readonly List<TargetController> TargetComponents = new();
    }
}
