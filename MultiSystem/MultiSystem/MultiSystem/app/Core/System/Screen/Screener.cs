using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MultiSystem.app.Core.System.Screen
{
    public class Screener
    {
        public double fullHeight {get; set;}
        public double fullWidth  {get; set;}
		private Dictionary<string, string> dictionarySize;
		
        public Screener() 
        {
            this.fullHeight = SystemParameters.FullPrimaryScreenHeight;
            this.fullWidth = SystemParameters.FullPrimaryScreenWidth;
        }

        public Dictionary<string, string> determineMenuLeftSize() 
        {
			dictionarySize = new Dictionary<string, string>();
			
			dictionarySize.Add("top",117.0+"");
			dictionarySize.Add("width",230.0+"");
			dictionarySize.Add("height",117.0+"");
			
			return dictionarySize;
        }

        private Dictionary<string, string> determineContainerSize() 
        {
			dictionarySize = new Dictionary<string, string>();
			
			dictionarySize.Add("top",117+"");
			dictionarySize.Add("width",(this.fullWidth-230.0f)+"");
			dictionarySize.Add("height",(this.fullHeight-117.0f-56.0f)+"");
			
			return dictionarySize;
        }
    }
}
