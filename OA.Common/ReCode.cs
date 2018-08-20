using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Common
{
    public class StateMsg
    {
        public string msg { get; set; }
        public int state { get; set; }

    }
    
    public static class ReCode
    {
        public enum State
        {
            /// <summary>
            /// 成功
            /// </summary>
            RECODE_OK = 0,
            /// <summary>
            /// 数据库查询错误
            /// </summary>
            RECODE_DBERR = 4001,
            /// <summary>
            /// 无数据
            /// </summary>
            RECODE_NODATA = 4002,
            /// <summary>
            /// 数据已存在
            /// </summary>
            RECODE_DATAEXIST = 4003,
            /// <summary>
            /// 数据错误
            /// </summary>
            RECODE_DATAERR = 4004,
            /// <summary>
            /// 用户未登录
            /// </summary>
            RECODE_SESSIONERR = 4101,
            /// <summary>
            /// 用户登录失败
            /// </summary>
            RECODE_LOGINERR = 4102,
            /// <summary>
            /// 参数错误
            /// </summary>
            RECODE_PARAMERR = 4103,
            /// <summary>
            /// 用户不存在或未激活
            /// </summary>
            RECODE_USERERR = 4104,
            /// <summary>
            /// 用户身份错误
            /// </summary>
            RECODE_ROLEERR = 4105,
            /// <summary>
            /// 密码错误
            /// </summary>
            RECODE_PWDERR = 4106,
            /// <summary>
            /// 非法请求或请求次数受限
            /// </summary>
            RECODE_REQERR = 4201,
            /// <summary>
            /// IP受限
            /// </summary>
            RECODE_IPERR = 4202,
            /// <summary>
            /// 第三方系统错误
            /// </summary>
            RECODE_THIRDERR = 4301,
            /// <summary>
            /// 文件读写错误
            /// </summary>
            RECODE_IOERR = 4302,
            /// <summary>
            /// 内部错误
            /// </summary>
            RECODE_SERVERERR = 4500,
            /// <summary>
            /// 未知错误
            /// </summary>
            RECODE_UNKNOWERR = 4501,
        }
        private static Dictionary<State, string> msg = new Dictionary<State, string>() {
            { State.RECODE_OK, "成功"},
            { State.RECODE_DBERR, "数据库查询错误"},
            { State.RECODE_NODATA, "无数据"},
            { State.RECODE_DATAEXIST, "数据已存在" },
            { State.RECODE_DATAERR, "数据错误"},
            { State.RECODE_SESSIONERR, "用户未登录"},
            { State.RECODE_LOGINERR, "用户登录失败"},
            { State.RECODE_PARAMERR, "参数错误"},
            { State.RECODE_USERERR, "用户不存在或未激活"},
            { State.RECODE_ROLEERR, "用户身份错误" },
            { State.RECODE_PWDERR, "密码错误"},
            { State.RECODE_REQERR, "非法请求或请求次数受限"},
            { State.RECODE_IPERR, "IP受限"},
            { State.RECODE_THIRDERR, "第三方系统错误" },
            { State.RECODE_IOERR, "文件读写错误" },
            { State.RECODE_SERVERERR, "内部错误"},
            { State.RECODE_UNKNOWERR, "未知错误"},
        };

        

        public static StateMsg GetResult(State state)
        {
            StateMsg rst = new StateMsg();
            rst.state = (int)state;
            rst.msg = msg[state];
            return rst;
        }

    }
}
