using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_Animation : MonoBehaviour
{
    public Sprite[] animationSprites;

    public float animationTime = 0.25f;

    private SpriteRenderer _spriteRenderer;

    private int _animationFrame;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }
    private void AnimateSprite()
    {
        _animationFrame++;

        if (_animationFrame >= this.animationSprites.Length)
        {
            _animationFrame = 0;
        }
        _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }
}
