using UnityEngine;
using Application = UnityEngine.Device.Application;

namespace Calculator._Scripts
{
    public class OutApp : MonoBehaviour
    {
        public void ExitApp()
        {
            Application.Quit();
        }
    }
}