using UnityEngine;

public class BackGroundController : MonoBehaviour
{

    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform layer;
        [Range(0, 1)] public float paralaxFactor;
    }

    public ParallaxLayer[] layer;

    public Transform camTransform;
    private Vector3 lastCameraPosition;  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastCameraPosition = camTransform.position;
    }

    // Update is called once per frame
    void lateUpdate()
    {
        
        Vector3 cameradelta = camTransform.position - lastCameraPosition;

        foreach(ParallaxLayer layer in layer)
        {
            float moveX = cameradelta.x * layer.paralaxFactor;
            float moveY = cameradelta.y * layer.paralaxFactor;

            layer.layer.position += new Vector3(moveX, moveY, 0);
        }

        lastCameraPosition = camTransform.position;

    }
}
