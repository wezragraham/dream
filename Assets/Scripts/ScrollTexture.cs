using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    Vector2 offset = Vector2.zero;
    Renderer myRenderer;

    [SerializeField]
    Vector2 scrollSpeed;

    private void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();

    }

    void Scroll()
    {
        offset += scrollSpeed * Time.deltaTime;

        myRenderer.materials[0].SetTextureOffset("_MainTex", offset);
    }
}
