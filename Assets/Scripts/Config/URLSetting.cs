﻿
public class URLSetting
{
    public static string START_UP_URL
    {
        get
        {
            // // TODO：外网启动地址，这个地址在发布线上游戏时自行部署和设置
            // return "https://chivas.framework.com/startup";

            return "http://172.16.20.206:8080";
        }
    }

    public static string APP_DOWNLOAD_URL
    {
        get;
        set;
    }

    public static string RES_DOWNLOAD_URL
    {
        get;
        set;
    }

    public static string LOGIN_URL
    {
        get;
        set;
    }

    public static string REPORT_ERROR_URL
    {
        get;
        set;
    }

    public static string SERVER_LIST_URL
    {
        get;
        set;
    }
    
    public static string NOTICE_URL
    {
        get;
        set;
    }
}
