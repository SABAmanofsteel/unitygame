using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonscript : MonoBehaviour
{
    public door door;
    private SpriteRenderer spriteRenderer;
    private bool pressed=false;
    public bool stayPressed=false;
    public Color redcolor;
    public Color greencolor;
    void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&!pressed)
        {
            pressed = true;
            door.buttonspressed++;
            spriteRenderer.color = greencolor;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player"&& pressed&&!stayPressed)
        {
            pressed = false;
            door.buttonspressed--;
            spriteRenderer.color = redcolor;
        }
    }
}
