using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf
{
    //Fonction utilisable
        //Toggle_Temps (Change le state du temps)


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

        public int Timescale = 45;
        private int DayScale;                                          //630 secondes réelle pour 14 heures si les heures du jeu se passent en 45 secondes
        private Color Morn_Dawn_Fog = new Color(0.21f, 0.21f, 0.150f); //BCBC90
        private Color Day_Noon_Fog = new Color(0.45f, 0.45f, 0.2f);
        private Color Dusk_Night_Fog = new Color(0f,0f,0f);
        public bool Temps_Fige = false;



        public void Initialisation()
        {
            Temps_Fige = false;
            DayScale = Timescale * 14; //print(DayScale);
            StartCoroutine(Temps_fonctionne());
            SetTime(TimeState.MORNING);
        }



        //Utilisé pour changé l'aspect visuel et divisé la journée.
        public void SetTime(TimeState timeState)
        {
            switch (timeState)
            {
                //Dawn - initialisation de l'horraire de la journée des NPC - réveil du joueur
                case TimeState.MORNING: default: RenderSettings.skybox = skyJour;
                    RenderSettings.ambientIntensity = 0.4f;
                    soleil.transform.rotation = Quaternion.Euler((new Vector3(160, 110, -1.5f)));
                    soleil.intensity = 0.5f;
                    RenderSettings.fogColor = Morn_Dawn_Fog;
                    RenderSettings.reflectionIntensity = 1f;
                    break;


                case TimeState.MIDMORNING: RenderSettings.skybox = skyJour;
                    RenderSettings.ambientIntensity = 0.55f;
                    soleil.transform.rotation = Quaternion.Euler((new Vector3(123, 124, 23)));
                    soleil.intensity = 0.8f;
                    break;


                case TimeState.MIDDAY: RenderSettings.skybox = skyJour;
                    RenderSettings.ambientIntensity = 1f;
                    soleil.transform.rotation = Quaternion.Euler((new Vector3(142, 178, 89)));
                    RenderSettings.fogColor = Day_Noon_Fog;
                    soleil.intensity = 0.8f;
                break;


                case TimeState.DAY: RenderSettings.skybox = skyJour;
                    RenderSettings.ambientIntensity = 1f;
                    soleil.transform.rotation = Quaternion.Euler((new Vector3(135, 207, 138)));
                    soleil.intensity = 0.8f;
                break;


                case TimeState.EVENING: RenderSettings.skybox = skyJour;
                    RenderSettings.ambientIntensity = 0.55f;
                    soleil.transform.rotation = Quaternion.Euler((new Vector3(147, 241, 182)));
                    soleil.intensity = 0.8f;
                break;

                
                case TimeState.NIGHT: RenderSettings.skybox = skyNight;
                    RenderSettings.ambientIntensity = 0.02f;
                    soleil.transform.rotation = Quaternion.Euler((new Vector3(175, 271, 222)));
                    soleil.intensity = 0.3f;
                    RenderSettings.fogColor = Dusk_Night_Fog;
                    RenderSettings.reflectionIntensity = 0;
                break;
            }
        }


        public IEnumerator Temps_fonctionne()
        {
            while (!Temps_Fige)
            {
                //Morn_630(0)   Mid_Morn_525(105)   Mid_Morn_420(210)   High_noon_315(315)  Noon_210(420)  Dusk_105(525)    Night_0(630)
                DayScale--; //print(DayScale);
                yield return new WaitForSeconds(1f);
            }
        }

        public void Toggle_Temps()
        {
            Temps_Fige = !Temps_Fige;  //Figer le temps ou résume le temps
        }


        //Le temps non arrêté
        public void Temps_Marche() {

        }


    }
}
