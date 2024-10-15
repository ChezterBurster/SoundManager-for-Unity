using UnityEngine;
using UnityEditor;

namespace SoundManagerAPI
{
    [CustomPropertyDrawer(typeof(RangedFloat), true)]
    public class SoundScriptsDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Inicializa la propiedad
            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            // Encontrar las propiedades de valor mínimo y máximo
            SerializedProperty minProp = property.FindPropertyRelative("minValue");
            SerializedProperty maxProp = property.FindPropertyRelative("maxValue");

            // Obtener los valores actuales
            float minValue = minProp.floatValue;
            float maxValue = maxProp.floatValue;

            // Establecer los valores predeterminados del rango
            float rangeMin = 0;
            float rangeMax = 1;

            // Obtener los atributos personalizados de rango mínimo y máximo
            var ranges = (MinMaxSliderAttribute[])fieldInfo.GetCustomAttributes(typeof(MinMaxSliderAttribute), true);
            if (ranges.Length > 0)
            {
                rangeMin = ranges[0].minValue;
                rangeMax = ranges[0].maxValue;
            }

            // Ancho de las etiquetas de los límites del rango
            const float rangeBoundsLabelWidth = 40f;

            // Dibujar el valor mínimo
            var rangeBoundsLabel1Rect = new Rect(position);
            rangeBoundsLabel1Rect.width = rangeBoundsLabelWidth;
            GUI.Label(rangeBoundsLabel1Rect, new GUIContent(minValue.ToString("F2")));
            position.xMin += rangeBoundsLabelWidth;

            // Dibujar el valor máximo
            var rangeBoundsLabel2Rect = new Rect(position);
            rangeBoundsLabel2Rect.xMin = rangeBoundsLabel2Rect.xMax - rangeBoundsLabelWidth;
            GUI.Label(rangeBoundsLabel2Rect, new GUIContent(maxValue.ToString("F2")));
            position.xMax -= rangeBoundsLabelWidth;

            // Dibujar el control deslizante de rango mínimo y máximo
            EditorGUI.BeginChangeCheck();
            EditorGUI.MinMaxSlider(position, ref minValue, ref maxValue, rangeMin, rangeMax);
            if (EditorGUI.EndChangeCheck())
            {
                // Actualizar los valores si han cambiado
                minProp.floatValue = minValue;
                maxProp.floatValue = maxValue;
            }

            EditorGUI.EndProperty();
        }
    }
}