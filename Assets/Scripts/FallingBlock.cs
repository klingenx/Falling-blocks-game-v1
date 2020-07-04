using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public Vector2 speedMinMax;
    float speed;
    float visibleHeightThreshold;
    public Color differentColors;
    public Renderer rend;

    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;


        ColorUpdate();
    }

    void Update()
    {

        transform.Translate (Vector3.down * speed * Time.deltaTime, Space.Self);
        if (transform.position.y < visibleHeightThreshold) {
            Destroy(gameObject);
        }
    }

    void ColorUpdate(){
        rend = GetComponent<Renderer>();
        differentColors = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );
        rend.material.color = differentColors;
    }
}
