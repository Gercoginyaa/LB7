using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OOP_LB7_3.Classes
{
    public class Article
    {
        public Article(string product, string price, string store,string index)
        {
            this._price = price;
            this._product = product;
            this._store = store;
            this._index = index;
        }

        private string _product;
        private string _price;
        private string _store;
        private string _index;


        public string Product
        {
            get { return _product; }
        }

        public string Price
        {
            get { return _price; }
        }

        public string Store
        {
            get { return _store; }
        }

        public string Index
        {
            get { return _index; }
        }
    }
}
