using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConsommiTounsiDotNet.Models;

namespace ConsommiTounsiDotNet.Models
{
	public class Users
	{
		public int id { get; set; }
		public String username { get; set; }

		public String lastName { get; set; }

		public String addresse { get; set; }

		public String sexe { get; set; }

		public String email { get; set; }

		public String password { get; set; }

		public Role role { get; set; }



		public Users (String name1 , String password1)
        {
			username = name1;
			password = password1;

		}

		public Users()
		{

		}




	}
}