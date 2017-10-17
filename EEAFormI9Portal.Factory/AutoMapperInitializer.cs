using AutoMapper;
using EEAFormI9Portal.EF;
using EEAFormI9Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEAFormI9Portal.Factory
{
    public class AutoMapperInitializer
    {
        public static void TwoWayMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AspNetUser,  >
            })
        }
    }
}
