using UnityEngine;

/*
 * This is an improved orbit script based on the MouseOrbitImproved script found
 * on the unity community wiki. It should run smoother then the original version 
*/
[AddComponentMenu("Camera-Control/Mouse Drag & Orbit with Zoom.")]
public class DragOrbitImproved : MonoBehaviour
{
    public Transform target; // player
    public float distance = 50.0f;
    public float xSpeed = 0.1f;
    public float ySpeed = 10.0f;
    public float distanceMin = 5;
    public float distanceMax = 100f;
    public float fluid = 2f;
    public float zoomSpeed = 100.0f;

    private float _rotationXAxis;
    private float _rotationYAxis;
    private float _velocityX;
    private float _velocityY;

    private void Start()
    {
        var angles = transform.eulerAngles;
        _rotationYAxis = angles.y;
        _rotationXAxis = angles.x;

        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>()) GetComponent<Rigidbody>().freezeRotation = true;
    }

    private void LateUpdate()
    {
        CameraOrbitDrag();
    }

    // Allow user to control camera with mouse.
    private void CameraOrbitDrag()
    {
        // activate Camera orbit & drag with right mouse click.
        if (!target) return;
        if (Input.GetMouseButton(1) && !PauseMenu.Paused)
        {
            // rotate Camera with Mouse in X + Y axis.
            _velocityX += xSpeed * Input.GetAxis("Mouse X") * distance * 0.02f;
            _velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;
        }

        _rotationYAxis += _velocityX;
        _rotationXAxis -= _velocityY;

        var toRotation = Quaternion.Euler(_rotationXAxis, _rotationYAxis, 0);
        // zoom in & out with mouse scroll wheel.
        distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, distanceMin, distanceMax);

        var negDistance = new Vector3(0.0f, 0.0f, -distance);
        var position = toRotation * negDistance + target.position;
        transform.rotation = toRotation;
        transform.position = position;

        // interpolates between '_velocity' and '0' by 'Time.deltaTime * fluid'
        _velocityX = Mathf.Lerp(_velocityX, 0, Time.deltaTime * fluid);
        _velocityY = Mathf.Lerp(_velocityY, 0, Time.deltaTime * fluid);

        // reduce mouse speed going under the Y Axis of target (player).
        if (position.y < 5) _velocityY = 0;
    }
}