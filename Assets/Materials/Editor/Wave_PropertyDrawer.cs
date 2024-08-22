using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

//[CustomPropertyDrawer(typeof(Wave))]
public class Wave_PropertyDrawer : PropertyDrawer
{
   /* public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        // Create a new VisualElement to be the root the property UI
        var container = new VisualElement();

        // Create drawer UI using C#
        var popup = new UnityEngine.UIElements.PopupWindow();
        popup.text = "Wave Details";
        popup.Add(new PropertyField(property.FindPropertyRelative("testNumber"), "Test this is"));
        popup.Add(new PropertyField(property.FindPropertyRelative("enemy"), "Enemy Types"));
        popup.Add(new PropertyField(property.FindPropertyRelative("enemyTypeSpawnChances"), "Spawn Chances"));
        
        container.Add(popup);

        // Return the finished UI
        return container;
    }*/
}
