using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace StonedFox.EditorExtensions
{
    // попроще делаем ReorderableList, если он один
    public class SingleReorderableListEditor : Editor
    {
        protected ReorderableList list;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            list.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }

        protected void InitList(ReorderableListBuilder builder)
        {
            list = builder.Build();

            if (builder.displayHeader)
            {
                list.drawHeaderCallback = DrawHeader;
            }
            if (builder.drawCustomElement)
            {
                list.drawElementCallback = DrawElement;
            }
        }

        protected virtual void DrawHeader(Rect rect)
        {

        }

        protected virtual void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
        {

        }
    }
}
