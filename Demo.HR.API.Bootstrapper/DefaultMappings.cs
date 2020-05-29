using System;
using System.Linq;
using AutoMapper;
using Demo.HR.Models.Db;
using Demo.HR.Models.Dtos;
using Demo.HR.Models.Dtos.Response;

namespace Demo.HR.API.Bootstrapper
{
    public class DefaultMappings : Profile
    {
        public DefaultMappings()
        {
            CreateMap<User, UserDto>()
                .ForMember(u => u.Projects, opt => opt.MapFrom(u => u.UserProjects.Where(up => up.IsActive).Select(up => up.Project)))
                .ForMember(u => u.Roles, opt => opt.MapFrom(u => u.UserRoles.Where(ur => ur.IsActive).Select(ur => ur.Role)))
                .ForMember(u => u.Allocations, opt => opt.MapFrom(u => u.UserAllocations));
            CreateMap<UserDto, User>()
                .ForMember(u => u.UserRoles, opt => opt.MapFrom(u => u.Roles.Select(r => new UserRole { IsActive = true, CreatedAt = DateTime.UtcNow, RoleId = r.Id, UserId = u.Id })))
                .ForMember(u => u.UserProjects, opt => opt.MapFrom(u => u.Projects.Select(r => new UserProject { IsActive = true, CreatedAt = DateTime.UtcNow, ProjectId = r.Id, UserId = u.Id })));
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Project, ProjectDto>()
                .ForMember(u => u.ActiveUsers, opt => opt.MapFrom(u => u.UserProjects.Where(up => up.IsActive).Select(up => up.User)));
            CreateMap<ProjectDto, Project>()
                .ForMember(p => p.UserProjects, opt => opt.MapFrom(p => p.ActiveUsers.Select(u => new UserProject { IsActive = true, CreatedAt = DateTime.UtcNow, UserId = u.Id, ProjectId = p.Id })));
            CreateMap<UserAllocation, UserAllocationDto>().ReverseMap();
        }
    }
}
