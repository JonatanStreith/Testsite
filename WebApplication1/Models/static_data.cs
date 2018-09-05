using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Datamanager_Mockup.Models
{
    public class static_data
    {

        public static List<VM_artikel> builddata()
        {
            List<VM_artikel> artikellista = new List<VM_artikel>();  //Mockup-data för visuell representation. Ska inte vara med i färdig produkt.

            artikellista.Add(new VM_artikel { a01TknKey = 1, ArticleNumber = "KIBMBo0010", Category = 5, Description = "Blå t-shirt", Stock = 10 });
            artikellista.Add(new VM_artikel { a01TknKey = 2, ArticleNumber = "KIBMBo0012", Category = 5, Description = "Grön t-shirt", Stock = 10 });
            artikellista.Add(new VM_artikel { a01TknKey = 3, ArticleNumber = "KIBMBo0014", Category = 5, Description = "Svart t-shirt", Stock = 10 });
            artikellista.Add(new VM_artikel { a01TknKey = 1, ArticleNumber = "KIBMBo0010", Category = 5, Description = "Blå t-shirt", Stock = 10 });
            artikellista.Add(new VM_artikel { a01TknKey = 2, ArticleNumber = "KIBMBo0012", Category = 5, Description = "Grön t-shirt", Stock = 10 });
            artikellista.Add(new VM_artikel { a01TknKey = 3, ArticleNumber = "KIBMBo0014", Category = 5, Description = "Svart t-shirt", Stock = 10 });
            artikellista.Add(new VM_artikel { a01TknKey = 1, ArticleNumber = "KIBMBo0010", Category = 5, Description = "Blå t-shirt", Stock = 10 });
            artikellista.Add(new VM_artikel { a01TknKey = 2, ArticleNumber = "KIBMBo0012", Category = 5, Description = "Grön t-shirt", Stock = 10 });
            artikellista.Add(new VM_artikel { a01TknKey = 3, ArticleNumber = "KIBMBo0014", Category = 5, Description = "Svart t-shirt", Stock = 10 });
            artikellista.Add(new VM_artikel { a01TknKey = 1, ArticleNumber = "KIBMBo0010", Category = 5, Description = "Blå t-shirt", Stock = 10 });
            artikellista.Add(new VM_artikel { a01TknKey = 2, ArticleNumber = "KIBMBo0012", Category = 5, Description = "Grön t-shirt", Stock = 10 });
            artikellista.Add(new VM_artikel { a01TknKey = 3, ArticleNumber = "KIBMBo0014", Category = 5, Description = "Svart t-shirt", Stock = 10 });
            artikellista.Add(new VM_artikel { a01TknKey = 1, ArticleNumber = "KIBMBo0010", Category = 5, Description = "Blå t-shirt", Stock = 10 });
            artikellista.Add(new VM_artikel { a01TknKey = 2, ArticleNumber = "KIBMBo0012", Category = 5, Description = "Grön t-shirt", Stock = 10 });
            artikellista.Add(new VM_artikel { a01TknKey = 3, ArticleNumber = "KIBMBo0014", Category = 5, Description = "Svart t-shirt", Stock = 10 });
            artikellista.Add(new VM_artikel { a01TknKey = 1, ArticleNumber = "KIBMBo0010", Category = 5, Description = "Blå t-shirt", Stock = 10 });
            artikellista.Add(new VM_artikel { a01TknKey = 2, ArticleNumber = "KIBMBo0012", Category = 5, Description = "Grön t-shirt", Stock = 10 });
            artikellista.Add(new VM_artikel { a01TknKey = 3, ArticleNumber = "KIBMBo0014", Category = 5, Description = "Svart t-shirt", Stock = 10 });
            artikellista.Add(new VM_artikel { a01TknKey = 1, ArticleNumber = "KIBMBo0010", Category = 5, Description = "Blå t-shirt", Stock = 10 });
            artikellista.Add(new VM_artikel { a01TknKey = 17, ArticleNumber = "LASBeD0112", Category = 1, Description = "Svart bensindriven drönare", Stock = 25 });


            return artikellista;
        }

        public static VM_artikel ReturnArticle(string ArticleNumber)        //Hitta artikel i artikellista mha artikelnummer
        {
            VM_artikel Article = static_data.builddata().Find(x => x.ArticleNumber == ArticleNumber);

            return Article;
        }

    }
}