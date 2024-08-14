using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace DotNet5Crud.Models
{
   
        public class Religion
        {
            public long ReligionId { get; set; }
            public string ReligionName { get; set; }
        }
    
}
