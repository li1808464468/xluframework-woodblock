---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by haitaoli.
--- DateTime: 2023/6/11 15:23
---

local GameSceneControl = BaseClass("GameSceneControl", Singleton)

function GameSceneControl:__init()
    print("------------ GameSceneControl init")
    self.checkedGroup = nil;
end

function GameSceneControl:CheckedGroup(blockGroup)
    print("设置选中BlockGroup")
    self.checkedGroup = blockGroup;
end

function GameSceneControl:UnCheckedGroup(bockGroup)
    self.checkedGroup = nil;
end

function GameSceneControl:getCheckedGroup()
    return self.checkedGroup
end

return GameSceneControl
