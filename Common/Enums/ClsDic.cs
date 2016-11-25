using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common.Enums
{
    /// <summary>
    /// 类描述:系统字典
    /// 创建标识:add yuangang by 2016-05-10
    /// </summary>
    public class ClsDic
    {
        public static string GetDicKeyByValue(string value, Dictionary<string, string> p)
        {
            if ((p != null) && (p.Count != 0))
            {
                Dictionary<string, string>.Enumerator enumerator = p.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    KeyValuePair<string, string> current = enumerator.Current;
                    if (current.Value == value)
                    {
                        return current.Key;
                    }
                }
            }
            return "";
        }

        public static string GetDicValueByKey(string key, Dictionary<string, string> p)
        {
            if ((p != null) && (p.Count != 0))
            {
                Dictionary<string, string>.Enumerator enumerator = p.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    KeyValuePair<string, string> current = enumerator.Current;
                    if (key == current.Key)
                    {
                        return current.Value;
                    }
                }
            }
            return "";
        }

        public static Dictionary<string, string> DicAttachmentPath =>
            new Dictionary<string, string> {
                {
                    "上传路径",
                    ConfigurationManager.AppSettings["upfile"]
                },
                {
                    "档案简历",
                    ConfigurationManager.AppSettings["upfile"]
                },
                {
                    "手机文件",
                    ConfigurationManager.AppSettings["upphone"]
                },
                {
                    "手机照片",
                    ConfigurationManager.AppSettings["photofile"]
                },
                {
                    "技术文件",
                    ConfigurationManager.AppSettings["upTsfile"]
                },
                {
                    "工程图",
                    ConfigurationManager.AppSettings["UploadFiles"]
                },
                {
                    "档案头像",
                    ConfigurationManager.AppSettings["upfile"]
                }
            };

        public static Dictionary<string, string> DicCodeType
        {
            get
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                try
                {
                    List<string> list = Utils.GetFileContent(HttpContext.Current.Server.MapPath("/Models/DicType.txt"), false).TrimEnd(new char[] { ',' }).TrimStart(new char[] { ',' }).Split(new char[] { ',' }).ToList<string>();
                    if (list.Count <= 0)
                    {
                        return dictionary;
                    }
                    foreach (string str2 in list)
                    {
                        dictionary.Add(str2.Split(new char[] { '-' })[0], str2.Split(new char[] { '-' })[1]);
                    }
                }
                catch
                {
                }
                return dictionary;
            }
        }

        public static Dictionary<string, string> DicCookie =>
            new Dictionary<string, string> {
                {
                    "Session中存储的帐号和CookieID",
                    "AccountCookieID_Session"
                },
                {
                    "Cookie中存储的帐号和CookieID",
                    "AccountCookieIDNew"
                }
            };

        public static Dictionary<string, string> DicCookieTimeout =>
            new Dictionary<string, string> { {
                "帐号过期时间",
                "30"
            } };

        public static Dictionary<string, string> DicEntity =>
            new Dictionary<string, string> {
                {
                    "日志",
                    ""
                },
                {
                    "用户",
                    "18da4207-3bfc-49ea-90f7-16867721805c"
                }
            };

        public static Dictionary<string, string> DicImageWH =>
            new Dictionary<string, string> {
                {
                    "图片宽度",
                    ConfigurationManager.AppSettings["imgWidth"]
                },
                {
                    "图片高度",
                    ConfigurationManager.AppSettings["imgHeight"]
                },
                {
                    "手机用户头像高",
                    ConfigurationManager.AppSettings["UserPhotoHeight"]
                },
                {
                    "手机用户头像宽",
                    ConfigurationManager.AppSettings["UserPhotoWidth"]
                },
                {
                    "用户头像高",
                    ConfigurationManager.AppSettings["PolicePhotoHeight"]
                },
                {
                    "用户头像宽",
                    ConfigurationManager.AppSettings["PolicePhotoWidth"]
                }
            };

        public static Dictionary<string, int> DicMailReadStatus =>
            new Dictionary<string, int> {
                {
                    "未读",
                    0
                },
                {
                    "已读",
                    1
                }
            };

        public static Dictionary<string, int> DicMailSendStatus =>
            new Dictionary<string, int> {
                {
                    "未发送",
                    0
                },
                {
                    "已发送",
                    1
                },
                {
                    "发送失败",
                    2
                }
            };

        public static Dictionary<string, int> DicMailType =>
            new Dictionary<string, int> {
                {
                    "发件箱",
                    0
                },
                {
                    "收件箱",
                    1
                },
                {
                    "垃圾箱",
                    2
                },
                {
                    "草稿箱",
                    3
                },
                {
                    "已删除",
                    4
                }
            };

        public static Dictionary<string, int> DicMessageType =>
            new Dictionary<string, int> {
                {
                    "广播",
                    0
                },
                {
                    "群组",
                    1
                },
                {
                    "私聊",
                    2
                }
            };

        public static Dictionary<string, string> DicPhone =>
            new Dictionary<string, string> {
                {
                    "安卓程序",
                    ConfigurationManager.AppSettings["AndroidName"]
                },
                {
                    "苹果程序",
                    ConfigurationManager.AppSettings["IOSName"]
                }
            };

        public static Dictionary<string, string> DicPoliceHouseImageWH =>
            new Dictionary<string, string> {
                {
                    "图片宽度",
                    ConfigurationManager.AppSettings["imgPoliceWidth"]
                },
                {
                    "图片高度",
                    ConfigurationManager.AppSettings["imgPoliceHeight"]
                }
            };

        public static Dictionary<string, int> DicProject =>
            new Dictionary<string, int> {
                {
                    "准备中",
                    0
                },
                {
                    "进行中",
                    1
                },
                {
                    "延期",
                    2
                },
                {
                    "已超时",
                    3
                },
                {
                    "已终止",
                    4
                },
                {
                    "已验收",
                    5
                },
                {
                    "已完成",
                    6
                },
                {
                    "已失败",
                    7
                },
                {
                    "已违约",
                    8
                },
                {
                    "对方违约",
                    9
                }
            };

        public static Dictionary<string, int> DicRole =>
            new Dictionary<string, int> { {
                "超级管理员",
                1
            } };

        public static Dictionary<string, int> DicStatus =>
            new Dictionary<string, int> {
                {
                    "驳回",
                    0
                },
                {
                    "通过",
                    1
                },
                {
                    "等待审核",
                    2
                }
            };

        public static Dictionary<string, string> OracleReportData =>
            new Dictionary<string, string> { {
                "OrcalReport",
                ConfigurationManager.AppSettings["connectionString"]
            } };
    }
}
