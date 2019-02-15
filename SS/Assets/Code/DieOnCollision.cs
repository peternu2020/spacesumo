using UnityEngine;

public class DieOnCollision : MonoBehaviour
{
    
    
    public AudioClip explosion;
    public AudioClip mlaunch;
    public AudioClip killscore;


    internal void OnCollisionEnter2D(Collision2D x)
    {
        if(x.gameObject.tag == "Missile" && this.gameObject.tag=="Enemy"){
            //FindObjectOfType<ScoreKeeper>().ScoreKill();
            GetComponent<AudioSource>().PlayOneShot(killscore, 0.9F);

            GetComponent<AudioSource>().PlayOneShot(explosion, 0.6F);
            //Invoke("DestroyEnemy", 1);

        }
       
        if(x.gameObject.tag == "Missile" && this.gameObject.tag=="Player"){
        //FindObjectOfType<ScoreKeeper>().EndGame();
        GetComponent<AudioSource>().PlayOneShot(explosion, 0.9F);

    }
       
    }
    void DestroyEnemy(){
        Destroy(gameObject);
    }
}
