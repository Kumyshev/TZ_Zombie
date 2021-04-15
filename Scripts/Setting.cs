using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewSetting", menuName = "ScriptableObjects/PlayProbability", order = 1)]
public class Setting : ScriptableObject
{
    [Range(5000, 50000)] public float BulletForce;
    [Range(1, 5)] public float HeroSpeed;
    [Range(0.09f, 0.9f)] public float FiringSpeed;
}
