using UnityEngine;

public class MouseScrollScale : MonoBehaviour
{
    // Maximum and minimum scale values
    public Vector2 maxScale = new Vector2(3f, 3f);
    public Vector2 minScale = new Vector2(1f, 1f);
    public float scale = 1f;
    // Speed of scaling
    public float scaleSpeed = 0.1f;
    public bool canResize = true;
    private Vector2 targetScale;

    void Start()
    {
        // Start with the object's initial scale
        targetScale = transform.localScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "noresize")
        {
            canResize = false;
        }
        if(collision.tag == "canresize")
        {
            canResize = true;
        }
    }


    void Update()
    {
        if (canResize)
        {
            scale = transform.localScale.x;
            // Get the scroll value from the mouse
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            if (scroll > 0f) // Scrolling forward
            {
                // Increase the scale but clamp it to the maxScale
                targetScale += Vector2.one * scaleSpeed;
                targetScale = Vector2.Min(targetScale, maxScale);
            }
            else if (scroll < 0f) // Scrolling backward
            {
                // Decrease the scale but clamp it to the minScale
                targetScale -= Vector2.one * scaleSpeed;
                targetScale = Vector2.Max(targetScale, minScale);
            }

            // Smoothly update the object's scale
            transform.localScale = Vector2.Lerp(transform.localScale, targetScale, Time.deltaTime * 10f);
        }
        
    }
}
