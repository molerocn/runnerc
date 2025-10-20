using UnityEngine;
 
[ExecuteInEditMode]
public class ParallaxCamera : MonoBehaviour
{
    public delegate void ParallaxCameraDelegate(float deltaMovement);
    public ParallaxCameraDelegate onCameraTranslate;
    public static ParallaxCamera Instance;
 
    private float oldPosition;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


 
    void Start()
    {
        oldPosition = transform.position.x;
    }
 
    void Update()
    {
        Debug.Log("ParallaxCamera Update");
        if (transform.position.x != oldPosition)
        {
            if (onCameraTranslate != null)
            {
                float delta = oldPosition - transform.position.x;
                onCameraTranslate(delta);
            }
 
            oldPosition = transform.position.x;
        }
    }
}
