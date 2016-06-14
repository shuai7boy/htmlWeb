using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace htmlWeb
{
    public class CreateHtm
    {
       private string fileName;

       public String FileName
       {
           get { return fileName; }
       }
       /// <summary>
       /// 读取配置文件
       /// </summary>
       /// <param name="dirName">配置文件的路径名</param>
       /// <param name="tag">配置文件中的标签名</param>
       /// <returns>_replaceStr的长度</returns>
       private int GetConfig(String dirName, String tag)
       {
           XmlDataDocument config = new XmlDataDocument();
           try
           {
               config.Load(dirName);
               //config.Load(@"G:\代码存放\ASP.NET代码存放\htmlWeb\UseT\config.xml");
           }
           catch (Exception ex)
           {
               throw ex;
           }
           XmlNodeList list = config.GetElementsByTagName(tag);
          // XmlNodeList list = config.GetElementsByTagName("article");
           return list.Count;
       }
        /// <summary>
        ///生成HTML文件
        /// </summary>
        /// <param name="configFileName">配置文件的路径名</param>
        /// <param name="configTag">配置文件中的标签名</param>
        /// <param name="dir">生成文件所在的文件夹的路径</param>
       /// <param name="templateFile">模板文件的的路径</param>
        /// <param name="param">要替换的字符串数组</param>
        /// <returns>生成的文件名</returns>
       public void MakeHtml(String configFileName, String configTag, String dir, String templateFile, String[] param)
       {
           fileName = null;
           int count = GetConfig(configFileName, configTag);
           String[] _replaceStr = new String[count];
           try
           {
               FileStream tFile = File.Open(templateFile, FileMode.Open, FileAccess.Read);
               StreamReader reader = new StreamReader(tFile, Encoding.GetEncoding("gb2312"));
               StringBuilder sb = new StringBuilder(reader.ReadToEnd());
               reader.Close();
               for (int i = 0; i < count; i++)
               {
                   sb.Replace("$replace[" + i + "]$", param[i]);
               }

               fileName = DateTime.Now.ToFileTime().ToString() + ".htm";

               FileStream rFile = File.Create(dir+"/" + fileName);
               StreamWriter writer = new StreamWriter(rFile, Encoding.GetEncoding("gb2312"));
               writer.Write(sb.ToString());
               writer.Flush();
               writer.Close();         

           }
           catch (Exception ex)
           {
               throw ex;
           }


       }

       public void DeleteHtml(String dirName)
       {
           File.Delete(dirName);
       }
    }
}
