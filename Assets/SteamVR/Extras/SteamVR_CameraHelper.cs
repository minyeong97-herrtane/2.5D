using UnityEngine;
using System.Collections;

namespace Valve.VR
{
	public class SteamVR_CameraHelper : MonoBehaviour
	{
		public float left = -0.135F;
		public float right = 0.135F;
		public float top = 0.075F;
		public float bottom = -0.075F;
		public float move_velocity = 0.01F;

		public SteamVR_Action_Pose poseActionR;
		public Camera Camera;

        static Matrix4x4 PerspectiveOffCenter(float left, float right, float bottom, float top, float near, float far)
        {
            float x = 2.0F * near / (right - left);
            float y = 2.0F * near / (top - bottom);
            float a = (right + left) / (right - left);
            float b = (top + bottom) / (top - bottom);
            float c = -(far + near) / (far - near);
            float d = -(2.0F * far * near) / (far - near);
            float e = -1.0F;
            Matrix4x4 m = new Matrix4x4();
            m[0, 0] = x;
            m[0, 1] = 0;
            m[0, 2] = a;
            m[0, 3] = 0;
            m[1, 0] = 0;
            m[1, 1] = y;
            m[1, 2] = b;
            m[1, 3] = 0;
            m[2, 0] = 0;
            m[2, 1] = 0;
            m[2, 2] = c;
            m[2, 3] = d;
            m[3, 0] = 0;
            m[3, 1] = 0;
            m[3, 2] = e;
            m[3, 3] = 0;
            return m;
        }

        void Start()
		{
#if OPENVR_XR_API && UNITY_LEGACY_INPUT_HELPERS
			if (this.gameObject.GetComponent<UnityEngine.SpatialTracking.TrackedPoseDriver>() == null)
			{
				this.gameObject.AddComponent<UnityEngine.SpatialTracking.TrackedPoseDriver>();
			}
#endif
		}

		private void Update()
		{
			/*
			 * Vector3 vPosition = poseActionR[SteamVR_Input_Sources.LeftHand].localPosition * 10;
			Quaternion qRotation = poseActionR[SteamVR_Input_Sources.LeftHand].localRotation;
            Camera.transform.localPosition = vPosition;
            print("Position : " + vPosition.x + "," + vPosition.y + "," + vPosition.z);
            */
        }
	}
}