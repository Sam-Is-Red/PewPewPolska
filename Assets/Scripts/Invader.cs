using Unity.VisualScripting;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites;

    public float animationTime = 1.0f;

    private SpriteRenderer _spriteRenderer;

    private int _animationFrame;

    public float health = 3f;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage) {

        health -= damage;
        if (health <= 0f)
        {
           //Instantiate(this.laserPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }
    private void AnimateSprite()
    {
        _animationFrame++;

        if(_animationFrame >= this.animationSprites.Length)
        {
            _animationFrame = 0;
        }
         _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }


    /*private void (Collision2D collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.name);

    }*/


}
