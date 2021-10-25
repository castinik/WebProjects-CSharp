using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CombinationsMakerConsole
{
    public class Container 
    {
    	public List<char> Vocab = new List<char>();
    	public string WordCombined { get; set; }
    	public int CharPosition { get; set; }
    	public int VocabPosition { get; set; }
    	
    	// function to copy new Container object
        public Container Copy()
        {
            Container copy = new Container()
            {
                Vocab = this.Vocab,
                WordCombined = this.WordCombined,
                CharPosition = this.CharPosition,
                VocabPosition = this.VocabPosition
            };
            return copy;
        }
    }
}