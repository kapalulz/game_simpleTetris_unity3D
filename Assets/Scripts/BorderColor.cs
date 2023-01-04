using UnityEngine;

public class BorderColor : MonoBehaviour
{
    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public float duration = 3.0F;

    private SpriteRenderer cam;

    //public static AudioSource audio;
    void Start()
    {
        cam = GetComponent<SpriteRenderer>();
        // cam.clearFlags = CameraClearFlags.SolidColor;
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        cam.color = Color.Lerp(color1, color2, t);
    }
}