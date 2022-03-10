# HOL-AOP

1. git clone https://github.com/isdaviddong/HOL-AOP.git
2. add NugGet package isRock.Framework.AOP
3. add class ExceptionHandler.cs
```
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

```
4. modify Program.cs
5. replace 
```
BMIProcessor BMI = new BMIProcessor();
```
with
```
BMIProcessor BMI = PolicyInjection.Create<BMIProcessor>();
```
6. replace 
```
public class BMIProcessor
```
with
```
public class BMIProcessor : PolicyInjectionComponentBase
```
7. replace 
```
public Decimal Calculate()
```
with
```
[ExceptionNotify(LogFileName = "log.txt")]
public Decimal Calculate()
```
