using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeController : MonoBehaviour {

    public GameObject heroContainer;
    public static float currentResolution = Screen.width / Screen.height;
    float maxX, maxY, minX, minY;
    public Camera mainCamera;
    public float defaultCameraHeight; // Default height for the camera.
    public float defaultCameraWidth() {
        return defaultCameraHeight * currentResolution;
    }
    public float cameraMargin;
	
    Vector2 GetHeroBox()
    {
        maxX = -999999;
        maxY = -999999;
        minX = 999999;
        minY = 999999;
        foreach (Transform child in heroContainer.transform)
        {
            float childX = child.position.x;
            float childY = child.position.y;
            if (childY > maxY) { maxY = childY; }
            if (childY < minY) { minY = childY; }
            if (childX > maxX) { maxX = childX; }
            if (childX < minX) { minX = childX; }
        }
        return new Vector2(Mathf.Abs(maxX - minX), Mathf.Abs(maxY - minY));
    }
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float cameraHeight;
        Vector2 boundingBox = GetHeroBox();
        if (boundingBox.x + cameraMargin > defaultCameraWidth())
        {
            cameraHeight = (boundingBox.x + cameraMargin) / currentResolution;
        }
        else if (boundingBox.y + cameraMargin > defaultCameraHeight)
        {
            cameraHeight = boundingBox.y + cameraMargin;
        }
        else
        {
            cameraHeight = defaultCameraHeight;
        }

        mainCamera.orthographicSize = cameraHeight;
	}
}
