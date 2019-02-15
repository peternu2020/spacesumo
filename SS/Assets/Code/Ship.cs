using UnityEngine;

public abstract class Ship : MonoBehaviour
{
    
    protected Rigidbody2D rigidBody;
    
    
    internal virtual void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
}