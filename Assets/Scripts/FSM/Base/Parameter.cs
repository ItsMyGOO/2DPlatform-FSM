using System;
using UnityEngine;

[Serializable]
public class Parameter
{
    [Header("属性")]
    [HideInInspector] public Animator animator;

    [HideInInspector] public SpriteRenderer sr;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public PhysicsCheck2D check;

    [Header("受伤与死亡")]
    [HideInInspector] public bool isHurt; // 是否受伤
    [HideInInspector] public bool isDead; // 是否死亡
}