using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UseT
{
    public class Test
    {
   public void main(){     
     string[] param = new string[4];
     param[0] = "测试模板";
     param[1] = "农佳捷";
     param[2] = "这是一个测试文章";
     param[3] = "2007-10-30";
     
     htmlWeb.CreateHtm cs = new htmlWeb.CreateHtm();

     cs.MakeHtml(@"G:\代码存放\ASP.NET代码存放\htmlWeb\UseT\config.xml", "article",@"G:\代码存放\ASP.NET代码存放\htmlWeb\UseT\Test\", @"G:\代码存放\ASP.NET代码存放\htmlWeb\UseT\templet.htm", param);
     
    }
    }    
}