using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    [Range(-5f, 5f)]
    public float scrollSpeedx;
    [Range(-5f, 5f)]
    public float scrollSpeedy;
    private float offsetx;
    private float offsety;
    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offsetx += (Time.deltaTime * scrollSpeedx) / 10f;
        offsety += (Time.deltaTime * scrollSpeedy) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offsetx, offsety));

    }
}
