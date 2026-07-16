using UnityEngine;

public class YSorting : MonoBehaviour
{
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        sr.sortingOrder = (int)(-(transform.position.y) * 2) + 10;
    }
}