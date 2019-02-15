using UnityEngine;

[RequireComponent(typeof(EnemyLauncher), typeof(Rigidbody2D) ) ]
public class Enemy : Ship //Player2
{
   
   
    private float placeholder;


    /// How fast we accelerate
    public float ThrustStrength = 1;
    /// How fast we turn
    public float Torque = 0.1f;

    public AudioClip explosion;
    public AudioClip mlaunch;
    public AudioClip killscore;

    private AudioSource audioSource;


    internal override void Start()
    {
        base.Start();
        
        audioSource = GetComponent<AudioSource>();
    }


   


    
    private void PlaySound(AudioClip clip)
    {
        if (clip == null)
        return;
        audioSource.loop = false;
        audioSource.PlayOneShot(clip);
    }
    
    internal void FixedUpdate() {
       /* 
        if (Input.GetKey(KeyCode.A))
        rigidBody.velocity = rigidBody.velocity + new Vector2(-0.05f, 0);
        
        else if (Input.GetKey(KeyCode.D))
        rigidBody.velocity = rigidBody.velocity + new Vector2(0.05f, 0);
        
        else  if (Input.GetKey(KeyCode.W))
        rigidBody.velocity = rigidBody.velocity + new Vector2(0, 0.05f);
        
        else  if (Input.GetKey(KeyCode.S))
        rigidBody.velocity = rigidBody.velocity + new Vector2(0, -0.05f);*/
        if (Input.GetKey(KeyCode.W))
            rigidBody.AddRelativeForce(new Vector2(ThrustStrength, 0));
        if (Input.GetKey(KeyCode.S))
            rigidBody.AddRelativeForce(new Vector2(-ThrustStrength, 0));
        if (Input.GetKey(KeyCode.A))
            rigidBody.AddTorque(Torque);
        else if (Input.GetKey(KeyCode.D))
            rigidBody.AddTorque(-Torque);
    
        else {return;}
    }

    internal void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)){
            GetComponent<EnemyLauncher>().FireMissile();
            GetComponent<AudioSource>().PlayOneShot(mlaunch, 0.7F);
        }
        
       var mainCamera = Camera.main;
       if (mainCamera)
       {
           var worldPosition = transform.position;
           var screenPosition = mainCamera.WorldToScreenPoint(worldPosition);
           var screenMax = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
           var screenMin = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));

           if (screenPosition.x < - 2
               || screenPosition.y < - 2
               || screenPosition.y > Screen.height + 2
               || screenPosition.x > Screen.width + 2)
           {
               //Destroy(gameObject);
               FindObjectOfType<ScoreKeeper>().P1ScoreIncrease(); //P1 wins
           }

       }
    }
}
