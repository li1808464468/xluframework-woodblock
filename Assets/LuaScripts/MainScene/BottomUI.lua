---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by haitao.li.
--- DateTime: 2023/5/5 8:51 AM
---
require "Framework.Common.BaseClass"
local LuaBehaviour = require "Framework.Common.LuaBehaviour"

local BottomUI = BaseClass("BottomUI", LuaBehaviour)

--------------------------需要序列化的数据--------------------------
BottomUI:AddDefineList({
    {name = "Content", type = CS.UnityEngine.Transform},
    {name = "Hold", type = CS.UnityEngine.GameObject}
})
--在编辑器下只加载DefineList,不管其他部分
if ExecuteInEditorScript then
    return BottomUI
end
--------------------------需要序列化的数据--------------------------

function BottomUI:initialize()
    LuaBehaviour.initialize(self)                       

end

function BottomUI:OnEnable()
    print("BottomUI OnEnable")
    print("BlockConfig.BlockGroup ", BlockConfig.BlockGroup);


    for i = 1, 3 do
        math.randomseed(os.time())

        local chara = GameObjectPool:GetInstance():GetGameObjectAsync(BlockConfig.BlockGroup, function(blockGroup)

            if IsNull(blockGroup) then
                error("Load chara res err!")
                do return end
            end



            local LuaBehaviour = blockGroup:GetComponent("LuaBehaviour")
            
            local startFunc =  LuaBehaviour.LuaInstance["Start"];

            if startFunc  then
                print("Start Function exist")
            else
                print("Start Function == null")
            end
            local randomInt = math.random(1, 19)
            
            print("randomInt ", randomInt)
            
            LuaBehaviour.LuaInstance:Start(randomInt)

            blockGroup.transform:SetParent(self.Content, false)
            blockGroup.transform.localPosition =  Vector3.New((i-2) * GameConfig.BottomWidth / 3, 0, 0);
            blockGroup.transform.localScale = GameConfig.GroupInitScale
        end)
    end
    
   

end


return BottomUI

