using UnityEngine;


public class EnemyLauncher : MonoBehaviour
{

    public GameObject MissilePrefab;



    public void FireMissile()
    {
        var shipVelocity = GetComponent<Rigidbody2D>().velocity;
        var missile = (GameObject) Object.Instantiate(MissilePrefab,
            transform.TransformPoint(new Vector3(0.5f, 0, 0)),
            transform.rotation); //Point missile in the same direction of ship
        var missileRigidBody = missile.GetComponent<Rigidbody2D>();
        missileRigidBody.velocity = MissileVelocity + shipVelocity;

    }

    private Vector2 MissileVelocity
    {
        get { return transform.TransformDirection(new Vector3(5, 0, 0)); }
    }
}

