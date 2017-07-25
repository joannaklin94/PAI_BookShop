using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using Rest.Data;
using System.IO;




namespace BranchService
{
    [ServiceContract]
    public interface IBookshopService 
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Books")]
        List<wsFullBookDescription> GetAllBooks();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Book/{BookId}")]
        wsFullBookDescription GetBook(string BookId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/BooksByCategory/{CategoryName}")]
        List<wsFullBookDescription> GetBooksbyCategory(string CategoryName);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/BooksByAuthor/{AuthorSurname}")]
        List<wsFullBookDescription> GetBooksbyAuthor(string AuthorSurname);

        [OperationContract]
        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json,
        UriTemplate = "/Book/{BookId}", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped)]
        void DeleteBook(string BookId);

        //working!!
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
        UriTemplate = "/Book", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped)]
        int AddBook(Stream JSONdataStream);
        

    }
}
