---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by haitao.li.
--- DateTime: 2023/6/13 9:40 AM
---

local BlockUtil = {}

local function ConvertLocalPosition(sourceImage, targetParent)
    local sourceRectTransform = sourceImage:GetComponent(typeof(CS.UnityEngine.RectTransform))
    local targetRectTransform = targetParent:GetComponent(typeof(CS.UnityEngine.RectTransform))
    
    local sourceLocalPosition = sourceRectTransform.localPosition
    local worldPosition = sourceRectTransform:TransformPoint(sourceLocalPosition)
    local targetLocalPosition = targetRectTransform:InverseTransformPoint(worldPosition)
    
    return targetLocalPosition
end


local function FindGameObjectInChildren(parent, targetName)
    for i = 1, parent.childCount do
        local child = parent:GetChild(i - 1)
        if child.name == targetName then
            return child
        else
            local found = FindGameObjectInChildren(child, targetName)
            if found then
                return found
            end
        end
    end
    return nil
end

local function FindGameObjectInCanvas(targetName)
    local canvas = CS.UnityEngine.GameObject.Find("Canvas")
    if not canvas then
        print("Canvas not found")
        return nil
    end

    return FindGameObjectInChildren(canvas.transform, targetName)
end

BlockUtil.ConvertLocalPosition = ConvertLocalPosition
BlockUtil.FindGameObjectInCanvas = FindGameObjectInCanvas
BlockUtil.FindGameObjectInChildren = FindGameObjectInChildren


return BlockUtil