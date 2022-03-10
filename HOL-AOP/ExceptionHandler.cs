using isRock.Framework.AOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOL_AOP
{

    public class ExceptionNotify : PolicyInjectionAttributeBase
    {
        //指定Log File Name
        public string LogFileName { get; set; }
        //override OnException方法
        public override void OnException(object sender, PolicyInjectionAttributeEventArgs e)
        {
            var msg = $"\r\n exception({DateTime.Now.ToString()}) : \r\n{e.Exception.Message }";
            //Console.Write(msg);
            SaveLog(msg);
        }

        //寫入Log
        private void SaveLog(string msg)
        {
            if (System.IO.File.Exists(LogFileName))
            {
                System.IO.File.AppendAllText(LogFileName, msg);
            }
            else
            {
                System.IO.File.WriteAllText(LogFileName, msg);
            }
        }
    }
}
