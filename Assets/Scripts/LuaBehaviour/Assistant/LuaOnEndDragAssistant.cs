/****************************************************
文件：LuaOnEndDragAssistant
作者：haitao.li
日期：2023/05/17 08:56:05
功能：OnEndDrag事件助手
*****************************************************/


using System;
using UnityEngine.EventSystems;
using XLua;

public class LuaOnEndDragAssistant : LuaAssistantBase, IEndDragHandler
{
    
    private Action<LuaTable, PointerEventData> onEndDragFunc;

    protected override void Awake()
    {
        base.Awake();
        onEndDragFunc = luaBehaviour.LuaInstance.Get<Action<LuaTable, PointerEventData>>("OnEndDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (luaBehaviour.LuaInstance != null)
        {
            onEndDragFunc?.Invoke(luaBehaviour.LuaInstance, eventData);
        }
    }
    void OnDestroy()
    {
        onEndDragFunc = null;
    }

   
}
