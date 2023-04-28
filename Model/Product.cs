using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallChamps.Model
{
    class Product
    {
		string name;
		string SourceImg;
		public Product(string name, string sourceImg)
		{
			this.name = name;
			this.SourceImg = sourceImg;
		}
	}
}
