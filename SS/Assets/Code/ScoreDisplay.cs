using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Display the current score
/// </summary>
// ReSharper disable once UnusedMember.Global
public class ScoreDisplay : MonoBehaviour
{
    public GUIStyle Style;
    public Rect Rect1 = new Rect(100, 100, 300, 100);
    public Rect Rect2 = new Rect(500, 500, 700, 500);

    private ScoreKeeper Player;

    internal void Start()
    {
        Player = GetComponent<ScoreKeeper>();
    }

    /// <summary>
    /// Display the score
    /// Called once each GUI update.
    /// </summary>
    internal void OnGUI()
    {
        GUI.Label(Rect1, $"P1 Score: {Player.P1Score:F3} P2 Score: {Player.P2Score:F3}", Style);
        if(Player.P1Win == true){
            GUI.Label(Rect2, $"Player1 Wins", Style);
            Invoke("EndUnity", 3);

            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            

        }
        if(Player.P2Win == true){
            GUI.Label(Rect2, $"Player2 Wins", Style);
            Invoke("EndUnity", 3);

            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void EndUnity(){
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
