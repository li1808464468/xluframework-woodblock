--[[
-- added by wsh @ 2017-11-15
-- 场景配置
-- 注意：
-- 1、level、name决定加载哪个物理场景
-- 2、Type决定加载哪个逻辑场景，多个逻辑场景可以使用同一个物理场景
--]]

local SceneConfig = {
	-- 启动场景
	LaunchScene = {
		-- level、name对应于BuldSetting中添加的场景
		Level = 0,
		Name = "LaunchScene",
		Type = nil,
	},
	-- 启动场景
	LoadingScene = {
		-- level、name对应于BuldSetting中添加的场景
		Level = 1,
		Name = "LoadingScene",
		Type = nil,
	},
	
	-- 启动场景
	MainScene = {
		-- level、name对应于BuldSetting中添加的场景
		Level = 2,
		Name = "MainScene",
		Type = require "Scenes.MainScene"
	}
	
}

return ConstClass("SceneConfig", SceneConfig)