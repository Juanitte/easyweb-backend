using Common.Dtos;
using System.ComponentModel;

namespace EasyWeb.UserMicroservice.Models.Dtos.FilterDto
{
    public class UserFilterRequestDto : GenericFilterRequestDto
    {
        [DefaultValue(false)]
        public bool Deleted { get; set; }
    }
}
