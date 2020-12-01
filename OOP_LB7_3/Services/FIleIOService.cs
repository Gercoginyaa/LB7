using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using OOP_LB7_3.Classes;

namespace OOP_LB7_3.Services
{
    class FIleIOService
    {
        public FIleIOService(string path)
        {
            this._path = path;
        }

        private readonly string _path;

        public BindingList<Article> LoadData()
        {
            var fileExists = File.Exists(_path);
            if (!fileExists)
            {
                File.Create(_path).Dispose();
                return new BindingList<Article>();
            }

            using (StreamReader mReader = File.OpenText(_path))
            {
                var filetext = mReader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Article>>(filetext);
            }
        }

        public void SaveData(BindingList<Article> myList)
        {
            using (StreamWriter myWriter = File.CreateText(_path))
            {
                string output = JsonConvert.SerializeObject(myList);
                myWriter.WriteLine(output);
            }
        }
    }
}
