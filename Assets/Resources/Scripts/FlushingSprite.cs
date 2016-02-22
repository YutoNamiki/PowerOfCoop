using UnityEngine;
using System.Collections;

public class FlushingSprite : MonoBehaviour {

    [SerializeField]
    public float Alpha = 0.0f;
    [SerializeField]
    public float Speed = 0.1f;
    [SerializeField]
    bool IsLighting = true;

    SpriteRenderer renderer;

	// Use this for initialization
	void Start () {

        renderer = GetComponent<SpriteRenderer>();
        if (renderer == null)
            throw new UnityException("FlushingSprite: SpriteRenderer is null.");

	}
	
	// Update is called once per frame
	void Update () {
	
        if (IsLighting)
        {
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, Alpha);
            if (Alpha >= 0.9f)
                IsLighting = false;
            Alpha += Time.deltaTime * Speed;
        }
        else
        {
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, Alpha);
            if (Alpha <= 0.1f)
                IsLighting = true;
            Alpha -= Time.deltaTime * Speed;
        }

	}
}
