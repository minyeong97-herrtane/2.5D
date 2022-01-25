using System;
using UnityEngine;
using UnityEngine.XR;
using UnityStandardAssets.Utility;
using Valve.VR;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class HeadBob : MonoBehaviour
    {
        public float near;
        public float far;
        public float left;
        public float right = 0.135F;
        public float top = 0.075F;
        public float bottom = -0.075F;
        public float move_velocity;
        public float scale;

        Vector3 monitorLeftupperPosition = new Vector3(-0.27f,1.3f, 0.49f);
        Vector3 monitorRightbottomPosition = new Vector3(0.32f, 0.92f, 0.49f);

        public Camera OurCamera;

        public SteamVR_Action_Pose poseActionR;

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
        }

        private void Update()
        {

            if (Input.GetKey("i")){
                top += Time.deltaTime * move_velocity;
                bottom += Time.deltaTime * move_velocity;
            }

            if(Input.GetKey("k")){
                top -= Time.deltaTime * move_velocity;
                bottom -= Time.deltaTime * move_velocity;
            }

            if (Input.GetKey("j"))
            {
                right -= Time.deltaTime * move_velocity;
                left -= Time.deltaTime * move_velocity;
            }

            if (Input.GetKey("l"))
            {
                right += Time.deltaTime * move_velocity;
                left += Time.deltaTime * move_velocity;
            }

        }

        private void LateUpdate()
        {
            
            Vector3 vPosition = poseActionR[SteamVR_Input_Sources.LeftHand].localPosition;
            Quaternion qRotation = poseActionR[SteamVR_Input_Sources.LeftHand].localRotation;
            //Camera.transform.localPosition = vPosition;
            // print("Position : " + vPosition.x + "," + vPosition.y + "," + vPosition.z);

            // update left, right, top, bottom
            Vector3 transposedMonitorLeftupperPos = monitorLeftupperPosition - vPosition;
            Vector3 transposedMonitorRightbottomPos = monitorRightbottomPosition - vPosition;

            // 베이스 스테이션 위치에 따라서 x랑 z축 방향이 반전될 수 있음
            // 그러면 코드를 바꿔주어야 함. 아래는 해당 사항에 대한 코드임
            // x는 왼쪽이 -, Z는 다가오는 쪽이 -, y는 위쪽이 플러스이므로, x랑 z축은 -를 붙여야 한다.
            left = transposedMonitorLeftupperPos.x * scale;
            right = transposedMonitorRightbottomPos.x * scale;
            top = transposedMonitorLeftupperPos.y * scale;
            bottom = transposedMonitorRightbottomPos.y * scale;
            near = transposedMonitorLeftupperPos.z * scale; // 일단은 이렇게 갈게
            far = 1000f;

            print("left:" + left + ", right:" + right + ", top:" + top + ", bottom:" + bottom + ", near:" + near);
            
            Matrix4x4 m = PerspectiveOffCenter(left, right, bottom, top, near, far);
            OurCamera.projectionMatrix = m;
        }
    }
}
