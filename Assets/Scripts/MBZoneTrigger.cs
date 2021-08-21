using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Madbricks
{
    public class MBZoneTrigger : MonoBehaviour
    {
        [SerializeField] bool good;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (good)
                {
                    MBLevelManager.MBlevelManager.Win();
                }
                else
                {
                    MBLevelManager.MBlevelManager.Lose();
                }
            }
        }
    }
}

