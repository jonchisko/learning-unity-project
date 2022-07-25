using UnityEngine;


namespace Waffle.PlatformSystems.Test
{
    public class DummyPlatformUser : MonoBehaviour
    {
        [SerializeField]
        PlatformView[] platformViews = new PlatformView[3];

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                platformViews[0].UsePlatform();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                platformViews[1].UsePlatform();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                platformViews[2].UsePlatform();
            }
        }
    }
}

