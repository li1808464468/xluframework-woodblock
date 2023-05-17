/****************************************************
文件：LuaOnPointerDownAssistant
作者：haitao.li
日期：2023/05/17 08:55:37
功能：OnPointerDown事件助手
*****************************************************/


using System;
using UnityEngine.EventSystems;
using XLua;

public class LuaOnPointerDownAssistant : LuaAssistantBase, IPointerDownHandler
{
    
    private Action<LuaTable, PointerEventData> onPointerDownFunc;

    protected override void Awake()
    {
        base.Awake();
        onPointerDownFunc = luaBehaviour.LuaInstance.Get<Action<LuaTable, PointerEventData>>("OnPointerDown");
    }

    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (luaBehaviour.LuaInstance != null)
        {
            onPointerDownFunc?.Invoke(luaBehaviour.LuaInstance, eventData);
        }
    }
    
    void OnDestroy()
    {
        onPointerDownFunc = null;
    }
}

