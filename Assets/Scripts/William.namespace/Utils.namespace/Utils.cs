using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace William.Utils
{

    public class Utils : MonoBehaviour
    {

        /*
         * Des functions utiles.
         * @author William Gingras 
         * @version 2018-25-04
        */

        //==============================// CONSTANTES //==============================//

        public const float PI = Mathf.PI;
        public const float HALF_PI = Mathf.PI / 2;
        public const float QUARTER_PI = Mathf.PI / 4;

        //==============================// FONCTIONS //==============================//

        public static float Perlin(float x, float y, float perlinWidth = 256, float perlinHeigth = 256, float noiseScale = 1, int octaves = 1)
        {
            // empeche les valeurs detres negatives
            if (x < 0) x = 0; if (y < 0) y = 0; if (perlinWidth < 0) perlinWidth = 0; if (perlinHeigth < 0) perlinHeigth = 0; if (noiseScale < 0) noiseScale = 0;

            float finalNoise = 0;
            for (int w = 0; w < octaves; w++)
            {
                float coordX = (x / perlinWidth * noiseScale * ((w == 0) ? 1 : 3f)) + octaves * 250;// coordX sur le bruit
                float coordY = (y / perlinHeigth * noiseScale * ((w == 0) ? 1 : 3f)) + octaves * 250;// coordY sur le bruit
                finalNoise += Mathf.PerlinNoise(coordX, coordY) / octaves;
            }

            return finalNoise; // renvoie la valeur de la coordonner
        }

        public static bool Chance(float chanceEnPourcentage)
        {
            return (Rdf(1, 100) > Mathf.Abs(chanceEnPourcentage - 100)) ? true : false;// vrai si reussie
        }

        public static int Rdi(int min, int max)
        {
            return Random.Range(min, max + 1);// retourne entre (int) min inclue et max inclue
        }

        public static float Rdf(float min, float max)
        {
            return Random.Range(min, max);// retourne entre (float) min inclue et max inclue
        }

        public static Vector3 RdV3(float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
        {
            return new Vector3(Rdf(xMin, xMax), Rdf(yMin, yMax), Rdf(zMin, zMax));
        }

        //Unity donne des angles négatifs difficiles d'utilisation, donc ce code retourne l'angle entre 0 et 360 degreer
        public static float AngleSansNegatif(float angle)
        {
            return (angle > 180) ? angle - 360 : angle;
        }

        //Limite un angle donné entre deux nombres float
        public static float LimiteAngle(float angle, float min, float max)
        {
            angle = AngleSansNegatif(angle);//Voir commentaire dans Ext.cs ligne 46
            angle = Mathf.Clamp(angle, min, max);
            return angle;
        }

    }

}
