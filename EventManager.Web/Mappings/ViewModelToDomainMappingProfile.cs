using AutoMapper;
using EventManager.Model;
using EventManager.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManager.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<EventFormViewModel, Event>()
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
                .ForMember(g => g.Location, map => map.MapFrom(vm => vm.Location))
                .ForMember(g => g.StartDate, map => map.MapFrom(vm => vm.StartDate))
                .ForMember(g => g.EndDate, map => map.MapFrom(vm => vm.EndDate))
                .ForMember(g => g.Id, map => map.MapFrom(vm => vm.Id));
        }
    }
}