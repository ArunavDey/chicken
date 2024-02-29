using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    // Load a sprite based on what you're supposed to load
    // Once you have the thing that you're supposed to load, look up how many frames of the animation you're supposed to load based on the lookup table.

    // AnimationManager provides an interface so that the player can just play the animation without a hassle (possibly within the playerController).

    void playAnimation(GameObject targetCharacter, String animationName, int frame) {
        // play the animation for the character, starting at that particular frame
        // Find the animation. This would likely exist as information that belongs to targetCharacter
        // Once you've found the animation to play, return the sprite?
    }

    // play the animation starting at the zeroth frame
    void playAnimation(GameObject targetCharacter, String animationName) {
        playAnimation(targetCharacter, animationName, 0);
    }
}
