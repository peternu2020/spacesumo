using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class ScoreKeeper : MonoBehaviour
{
    private int P1score = 0;
    private int P2score = 0;
    
    public bool P1Win = false;
    public bool P2Win = false;


    public float P1Score
    {
        get
        {
            return P1score;
        }
    }
    
    public float P2Score
    {
        get
        {
            return P2score;
        }
    }
    
    public void P1ScoreIncrease()
    {
        P1score++;
        P1Win = true;
    }
    
    public void P2ScoreIncrease()
    {
        P2score++;
        P2Win = true;
    }
    
    
}