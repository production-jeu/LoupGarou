using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf
{
    /*
     * Manager du temps
     * @version 2028-10-22
     * @author William Gingras
     */
    public class TimeManager : MonoBehaviour
    {
        #region Singleton
        public static TimeManager instance;
        private void Awake()
        {
            instance = this;
        }
        #endregion

        public enum TimeState { MORNING, MIDMORNING, MIDDAY, DAY, EVENING, NIGHT }

        public Light soleil;
        public Light lune;

        public Material skyJour;
        public Material skyNight;

        public void Initialisation()
        {
            //SetTime(TimeState.NIGHT);
        }

        public void SetTime(TimeState timeState)
        {
            switch (timeState)
            {
                case TimeState.MORNING: default: RenderSettings.skybox = skyJour; RenderSettings.ambientIntensity = 0.5f; soleil.transform.rotation = Quaternion.Euler((new Vector3(-183, 0, 0))); soleil.intensity = 0.5f; break;
                case TimeState.MIDMORNING: RenderSettings.skybox = skyJour; RenderSettings.ambientIntensity = 0.75f; soleil.transform.rotation = Quaternion.Euler((new Vector3(130, 0, 0))); soleil.intensity = 0.75f; break;
                case TimeState.MIDDAY: RenderSettings.skybox = skyJour; RenderSettings.ambientIntensity = 1f; soleil.transform.rotation = Quaternion.Euler((new Vector3(90, 0, 0))); soleil.intensity = 1.5f; break;
                case TimeState.DAY: RenderSettings.skybox = skyJour; RenderSettings.ambientIntensity = 1f; soleil.transform.rotation = Quaternion.Euler((new Vector3(-310, 0, 0))); soleil.intensity = 1; break;
                case TimeState.EVENING: RenderSettings.skybox = skyJour; RenderSettings.ambientIntensity = 0.5f; soleil.transform.rotation = Quaternion.Euler((new Vector3(-350, 0, 0))); soleil.intensity = 0.5f; break;
                case TimeState.NIGHT: RenderSettings.skybox = skyNight; RenderSettings.ambientIntensity = 0.05f; soleil.transform.rotation = Quaternion.Euler((new Vector3(-23, 0, 0))); soleil.intensity = 0; break;
            }
        }

    }
}
