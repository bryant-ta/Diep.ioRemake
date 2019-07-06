using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public int zoom;

    Vector3 curPos;
    Vector2 dir;

    Camera viewCam;
    CameraFollowTarget cft;

    bool reset;

    private void Start()
    {
        viewCam = Camera.main;
        cft = viewCam.GetComponent<CameraFollowTarget>();
    }

    float nextLook;
    private void Update()
    {
        if (Input.GetButton("Fire2"))   // Don't press a lot lol
        {
            cft.enabled = false;
            viewCam.transform.position = new Vector3(curPos.x + dir.x, curPos.y + dir.y, curPos.z) * zoom;
            reset = true;
        }
        else
        {
            if (reset)
            {
                viewCam.transform.position = curPos;
                reset = false;
            }
            cft.enabled = true;
            Vector3 mousePos = viewCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
            dir = (mousePos - transform.position);
            print("DIR : " + dir);
            curPos = viewCam.transform.position;
        }
    }
}