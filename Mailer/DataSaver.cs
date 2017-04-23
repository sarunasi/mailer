using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Mailer
{
    public class DataSaver<T>
    {
        public void SaveDataList(string username, List<T> dataList)
        {
            IFormatter formatter = new BinaryFormatter();

            Stream stream = new FileStream(username + ".bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, dataList);
            stream.Close();

        }

        public List<T> LoadDataList(string username)
        {

                List<T> data;

                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(username + ".bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                data = (List<T>)formatter.Deserialize(stream);
                stream.Close();

                return data;


        }
    }
}
