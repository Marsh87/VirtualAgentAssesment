using System.Web.UI.WebControls;
using AutoMapper;

namespace VirtualAgentAssessment.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Configure() {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperProfile>();
            });
            return mapperConfiguration;
        }
    }
}