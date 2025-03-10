using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left);
    }
}
