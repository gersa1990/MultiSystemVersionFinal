using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MultiSystem.app.Library.Models;
using System.ComponentModel;

namespace MultiSystem.app.Library.Controllers
{
	public class GenereController
	{
		
		private GenereModel model = new GenereModel();
		
		public GenereController()
		{
			
		}
		
		public List<Dictionary<string, string>> getGeneres()
		{
			return model.getGeneres();
		}

        public List<WorkItem> getGeneresForWorkItem() 
        {

            List<Dictionary<string, string>> generesBook = model.getGeneres();
            List<WorkItem> comboGenereBook = new List<WorkItem>();

            int i = 0;
            string val = "";

            foreach (var item in generesBook)
            {
                foreach (var row in item)
                {
                    switch (row.Key)
                    {
                        case "idGenereBook":
                            i = int.Parse(row.Value);
                            break;
                        case "nameGenereBook":
                            val = row.Value;
                            break;
                    }

                    if (!val.Equals("") && i != 0)
                    {
                        comboGenereBook.Add(new WorkItem { Key = i, Value = val });
                        i = 0;
                        val = "";
                    }
                }
            }

            return comboGenereBook;
        }

        public int addGenere(Dictionary<string, string> setParameters) 
        {
            return model.addGenere(setParameters);
        }

        public List<GenereBook> getAllGeneres() 
        {
            List<Dictionary<string, string>> generes = model.getGeneres();
            List<GenereBook> generesList = new List<GenereBook>();

            foreach (var gen in generes) 
            {
                GenereBook genereObj = new GenereBook();
                foreach (var item in gen) 
                {
                    switch(item.Key)
                    {
                        case "idGenereBook":
                            genereObj.idGenereBook = int.Parse(item.Value);
                        break;

                        case "nameGenereBook":
                            genereObj.nameGenereBook = item.Value;
                        break;

                        case "descriptionGenereBook":
                        genereObj.descriptionGenereBook = item.Value;
                        break;
                    }
                }

                generesList.Add(genereObj);
            }

            return generesList;
        }

        public int editGenere(Dictionary<string, string> setParameters, Dictionary<string, string> whereParameters)
        {
            return model.updateGenere(setParameters, whereParameters);
        }

        public int deleteGenere(Dictionary<string, string> whereParameters)
        {
            return model.deleteGenereModel(whereParameters);
        }
    }

    public class GenereBook 
    {
        public int idGenereBook { get; set; }
        
        [DisplayName("Género")]
        public string nameGenereBook { get; set; }

        [DisplayName("Descripción")]
        public string descriptionGenereBook { get; set; }
    }

    public class WorkItem
    {
        public int Key { get; set; }
        public string Value { get; set; }

        public WorkItem()
        {
        }

        public WorkItem(int key, string value) 
        {
            this.Key = key;
            this.Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}