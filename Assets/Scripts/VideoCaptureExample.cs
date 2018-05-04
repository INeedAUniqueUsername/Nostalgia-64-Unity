using UnityEngine;
using System.Collections;
using System.Linq;


public class VideoCaptureExample : MonoBehaviour {
    UnityEngine.XR.WSA.WebCam.VideoCapture m_VideoCapture = null;
    float m_stopRecordingTimer = float.MaxValue;

    // Use this for initialization
    void Start() {
        StartVideoCaptureTest();
    }

    void Update() {
        if (m_VideoCapture == null || !m_VideoCapture.IsRecording) {
            return;
        }

        if (Input.GetKey(KeyCode.Return)) {
            m_VideoCapture.StopRecordingAsync(OnStoppedRecordingVideo);
            Application.Quit();
        }
    }

    void StartVideoCaptureTest() {

        Resolution cameraResolution = UnityEngine.XR.WSA.WebCam.VideoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();
        Debug.Log(cameraResolution);

        float cameraFramerate = UnityEngine.XR.WSA.WebCam.VideoCapture.GetSupportedFrameRatesForResolution(cameraResolution).OrderByDescending((fps) => fps).First();
        Debug.Log(cameraFramerate);

        UnityEngine.XR.WSA.WebCam.VideoCapture.CreateAsync(false, delegate (UnityEngine.XR.WSA.WebCam.VideoCapture videoCapture) {
            if (videoCapture != null) {
                m_VideoCapture = videoCapture;
                Debug.Log("Created VideoCapture Instance!");

                UnityEngine.XR.WSA.WebCam.CameraParameters cameraParameters = new UnityEngine.XR.WSA.WebCam.CameraParameters();
                cameraParameters.hologramOpacity = 0.0f;
                cameraParameters.frameRate = cameraFramerate;
                cameraParameters.cameraResolutionWidth = cameraResolution.width;
                cameraParameters.cameraResolutionHeight = cameraResolution.height;
                cameraParameters.pixelFormat = UnityEngine.XR.WSA.WebCam.CapturePixelFormat.BGRA32;

                m_VideoCapture.StartVideoModeAsync(cameraParameters,
                                                   UnityEngine.XR.WSA.WebCam.VideoCapture.AudioState.ApplicationAndMicAudio,
                                                   OnStartedVideoCaptureMode);
            } else {
                Debug.LogError("Failed to create VideoCapture Instance!");
            }
        });
    }

    void OnStartedVideoCaptureMode(UnityEngine.XR.WSA.WebCam.VideoCapture.VideoCaptureResult result) {
        Debug.Log("Started Video Capture Mode!");
        string timeStamp = Time.time.ToString().Replace(".", "").Replace(":", "");
        string filename = string.Format("TestVideo_{0}.mp4", timeStamp);
        string filepath = System.IO.Path.Combine(Application.persistentDataPath, filename);
        filepath = filepath.Replace("/", @"\");
        m_VideoCapture.StartRecordingAsync(filepath, OnStartedRecordingVideo);
    }

    void OnStoppedVideoCaptureMode(UnityEngine.XR.WSA.WebCam.VideoCapture.VideoCaptureResult result) {
        Debug.Log("Stopped Video Capture Mode!");
    }

    void OnStartedRecordingVideo(UnityEngine.XR.WSA.WebCam.VideoCapture.VideoCaptureResult result) {
        Debug.Log("Started Recording Video!");
    }

    void OnStoppedRecordingVideo(UnityEngine.XR.WSA.WebCam.VideoCapture.VideoCaptureResult result) {
        Debug.Log("Stopped Recording Video!");
        m_VideoCapture.StopVideoModeAsync(OnStoppedVideoCaptureMode);
    }
}