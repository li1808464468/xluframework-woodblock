/****************************************************
文件：LuaOnBeginDragAssistant
作者：haitao.li
日期：2023/05/17 08:56:37
功能：OnBeginDrag事件助手
*****************************************************/


using System;
using UnityEngine.EventSystems;
using XLua;

public class LuaOnBeginDragAssistant : LuaAssistantBase, IBeginDragHandler
{
    private Action<LuaTable, PointerEventData> onBeginDragFunc;

    protected override void Awake()
    {
        base.Awake();
        onBeginDragFunc = luaBehaviour.LuaInstance.Get<Action<LuaTable, PointerEventData>>("OnBeginDrag");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (luaBehaviour.luaInstance != null)
        {
            onBeginDragFunc?.Invoke(luaBehaviour.luaInstance, eventData);
        }
    }
    
    void OnDestroy()
    {
        onBeginDragFunc = null;
    }

    
}
