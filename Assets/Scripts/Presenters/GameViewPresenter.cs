using UnityEngine;

public class GameViewPresenter : MonoBehaviour
{
    [System.Serializable]
    public class Pose
    {
        /// <summary>
        /// Desired transform of the Camera GameObject.
        /// </summary>
        public Transform Camera;

        /// <summary>
        /// Desired transform of the Hand GameObject.
        /// </summary>
        public Transform Hand;
    }

    [SerializeField]
    Pose observePlayingField;

    [SerializeField]
    Pose neutral;

    [SerializeField]
    Pose observeHand;

    [SerializeField]
    [NotNull]
    new Transform camera;

    [SerializeField]
    [NotNull]
    Transform hand;

    public enum PoseState
    {
        ObserveHand,
        Neutral,
        ObservePlayingField,
    }

    /// <summary>
    /// Initial value of CurrentPose.
    ///
    /// Everywhere else, you should use the CurrentPose property.
    /// </summary>
    PoseState _currentPoseState = PoseState.Neutral;

    public PoseState CurrentPoseState
    {
        get { return _currentPoseState; }
        set { _currentPoseState = value; }
    }

    public Pose CurrentPose
    {
        get
        {
            return CurrentPoseState switch
            {
                PoseState.ObserveHand => observeHand,
                PoseState.Neutral => neutral,
                PoseState.ObservePlayingField => observePlayingField,
                _ => throw new System.Exception($"PoseState {CurrentPoseState} not covered."), // Sadly not a compile-time check, ah well.
            };
        }
    }

    /// <summary>
    /// Ease between positions for the camera and hand.
    /// </summary>
    void MoveTowards(Pose pose)
    {
        if (Vector3.Distance(camera.transform.position, pose.Camera.position) > 0.001f)
        {
            var speed = 2f;
            var step = speed * Time.deltaTime;
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, pose.Camera.position, step);
        }
        if (Vector3.Distance(hand.transform.position, pose.Hand.position) > 0.001f)
        {
            var speed = 2f;
            var step = speed * Time.deltaTime;
            hand.transform.position = Vector3.MoveTowards(hand.transform.position, pose.Hand.position, step);
        }
    }

    /// <summary>
    /// Ease between rotations for the camera and hand.
    /// </summary>
    void RotateTowards(Pose pose)
    {
        {
            var maxDegreesPerSecond = 90;
            var step = maxDegreesPerSecond * Time.deltaTime;
            camera.transform.rotation = Quaternion.RotateTowards(camera.transform.rotation, pose.Camera.rotation, step);
        }
        {
            var maxDegreesPerSecond = 180;
            var step = maxDegreesPerSecond * Time.deltaTime;
            hand.transform.rotation = Quaternion.RotateTowards(hand.transform.rotation, pose.Hand.rotation, step);
        }
    }

    void HandleCurrentPoseChanged()
    {
        var currentPoseInt = (int)CurrentPoseState;
        if (Input.GetKeyDown(KeyCode.W)) currentPoseInt++;
        else if (Input.GetKeyDown(KeyCode.S)) currentPoseInt--;
        currentPoseInt = Mathf.Clamp(currentPoseInt, 0, (int)PoseState.ObservePlayingField);
        CurrentPoseState = (PoseState)currentPoseInt;
    }

    void Update()
    {
        HandleCurrentPoseChanged();
        MoveTowards(CurrentPose);
        RotateTowards(CurrentPose);
    }
}
