using isRock.Framework.AOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOL_AOP
{
    public class Logging : PolicyInjectionAttributeBase
    {
        //指定Log File Name
        public string LineNotifyToken { get; set; }
        public string Message { get; set; }
        //override AfterInvoke方法
        public override void AfterInvoke(object sender, PolicyInjectionAttributeEventArgs e)
        {
            isRock.LineNotify.Utility.SendNotify(LineNotifyToken, Message);
        }
    }
}
