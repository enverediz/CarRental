using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarImageDetailDto : IDto
    {        
        public string CarName { get; set; }
        public string ImagePath { get; set; }

    }
}
