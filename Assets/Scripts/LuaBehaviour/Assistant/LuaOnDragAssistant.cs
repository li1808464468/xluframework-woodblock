/****************************************************
文件：LuaOnDragAssistant
作者：haitao.li
日期：2023/05/17 08:54:20
功能：OnDrag事件助手
*****************************************************/

using System;
using UnityEngine.EventSystems;
using XLua;

public class LuaOnDragAssistant : LuaAssistantBase, IDragHandler
{
    
    private Action<LuaTable, PointerEventData> onDragFunc;

    protected override void Awake()
    {
        base.Awake();
        onDragFunc = luaBehaviour.LuaInstance.Get<Action<LuaTable, PointerEventData>>("OnDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (luaBehaviour.LuaInstance != null)
        {
            onDragFunc?.Invoke(luaBehaviour.LuaInstance, eventData);
        }
    }
    
    void OnDestroy()
    {
        onDragFunc = null;
    }
    
}
