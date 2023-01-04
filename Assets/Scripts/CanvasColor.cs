using UnityEngine;
using UnityEngine.UI;

public class CanvasColor : MonoBehaviour
{
    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public float duration = 3.0F;
    
    private Color cam;

    void Start()
    {
        cam = GetComponent<Image>().color;
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        cam = Color.Lerp(color1, color2, t);
       
        GetComponent<Image>().color = cam;
        
    }
}