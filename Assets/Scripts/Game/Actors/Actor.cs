using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    protected new Transform transform;
    protected SpriteRenderer spriteRenderer;
    protected AudioSource aux;

    protected MazeGenerator mazeGenerator;

    protected Vector2 moveDirection;
    public Vector2 LastNonzeroDirection { get; protected set; }

    protected virtual void Awake()
    {
        transform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        aux = GetComponentInChildren<AudioSource>();

        mazeGenerator = FindObjectOfType<MazeGenerator>();
    }

    void Update()
    {
        Move();

        if (!moveDirection.Equals(Vector2.zero))
        {
            if (!aux.isPlaying)
            {
                print($"{name} is playing footestpes.");
                aux.Play();
            }
        }
    }

    protected abstract void Move();
}