using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public readonly List<SquareController> squareComponents = new();
    public readonly List<TargetController> targetComponents = new();
}
