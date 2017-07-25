using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;


namespace Rest.Data
{
    [DataContract]
    public class wsBook
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public int Year { get; set; }

        [DataMember]
        public int Price { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public int Id_Author { get; set; }

        [DataMember]
        public int Id_Category { get; set; }

        [DataMember]
        public int Id_Language { get; set; }

    }
}


