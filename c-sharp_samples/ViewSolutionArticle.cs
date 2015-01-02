using System;
using System.Net;
using System.Text;
using System.IO;

class Program
{
    static void Main()
    {
      string test = String.Empty;
      // Example : HttpWebRequest request =(HttpWebRequest)WebRequest.Create("http://domain.freshdesk.com/solution/categories/4/folders/1/articles/1.json");  
      HttpWebRequest request =(HttpWebRequest)WebRequest.Create("http://domain.freshdesk.com/solution/categories/[category_id]/folders/[folder_id]/articles/[id].json");  
      request.ContentType = "application/json"; 
      request.Method = "GET"; 
      string authInfo = "Api_Key:X";
      authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
      request.Headers["Authorization"] ="Basic "+authInfo;
      using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
      {
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        test = reader.ReadToEnd();
        reader.Close();
        dataStream.Close();
      }  
      Console.Out.WriteLine(test);
    }
}