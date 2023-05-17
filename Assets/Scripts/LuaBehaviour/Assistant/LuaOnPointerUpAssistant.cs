/****************************************************
文件：LuaOnPointerUpAssistant
作者：haitao.li
日期：2023/05/17 09:11:05
功能：Nothing
*****************************************************/

using System;
using UnityEngine.EventSystems;
using XLua;

public class LuaOnPointerUpAssistant : LuaAssistantBase, IPointerUpHandler
{

    private Action<LuaTable, PointerEventData> onPointerUpFunc;

    protected override void Awake()
    {
        base.Awake();
        onPointerUpFunc = luaBehaviour.LuaInstance.Get<Action<LuaTable, PointerEventData>>("OnPointerUp");
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        if (luaBehaviour.LuaInstance != null)
        {
            onPointerUpFunc?.Invoke(luaBehaviour.LuaInstance, eventData);
        }    
    }

    void OnDestroy()
    {
        onPointerUpFunc = null;
    }

    
}
    