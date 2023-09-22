using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

//[CustomEditor(typeof(EnemySpawn))]
public class GameManagerInspector : Editor
{
    /*public override VisualElement CreateInspectorGUI()
    {
        // Create a new VisualElement to be the root of our inspector UI
        VisualElement myInspector = new VisualElement();

        //Adding a label
        myInspector.Add(new Label("This is a custom inspector"));

        VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/wavesSet_UXML.uxml");
        visualTree.CloneTree(myInspector);

        //Returing the finished inspector UI
        return myInspector;
    }*/
}
