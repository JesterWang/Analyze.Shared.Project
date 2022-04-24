using Analyze.Shared.Common.Report;
using Analyze.Shared.DataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analyze.Shared.Project.Utility
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<par_information_summary, ParInformationSummary>()
                .ForMember(c => c.create_time, b => b.MapFrom(c => c.create_time.ToString("yyyy-MM-dd HH:mm:ss")));
        }
    }
}