using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private Sounds sound;
    public int best;
    
    public void Check()
    {
        best++; 
        score.text = best.ToString();
    }
    public void PlaySound()
    {
        sound.PlayGetPointSound();
    }
    
}
