using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madbricks
{
    public class MBInputManager : MonoBehaviour
    {
        public static MBInputManager MBinputManager;
        public Vector2 Direction { get; private set; }

        public bool SpecialPressedThisFrame => Input.GetKeyDown(KeyCode.Space);

        private void Awake()
        {
            if (MBinputManager == null)
            {
                MBinputManager = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else if (MBinputManager != this)
            {
                Destroy(this.gameObject);
            }
        }

        private void Update()
        {
            UpdateDirection();
        }

        private void UpdateDirection()
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Direction = Vector2.right;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                Direction = Vector2.left;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                Direction = Vector2.up;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                Direction = Vector2.down;
            }
            else
            {
                Direction = Vector2.zero;
            }
        }
    }
}