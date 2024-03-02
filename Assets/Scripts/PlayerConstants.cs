using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConstants : MonoBehaviour
{
    public static String jump = "Jump";
    public static String idle = "Idle";
    public static String walkLeft = "Walk Left";
    public static String walkRight = "Walk Right";

    // need another SortedDictionary to map String to actual animation
    SortedDictionary<String, int> numberOfFramesPerAnimation;
}
