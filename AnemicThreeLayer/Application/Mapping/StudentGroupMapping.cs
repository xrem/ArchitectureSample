using Application.Dto;
using DataAccess.Models;

namespace Application.Mapping;

public static class StudentGroupMapping
{
    public static StudentGroupDto AsDto(this StudentGroup group)
    {
        return new StudentGroupDto(group.Id, group.Name, group.Students.Select(x => x.AsDto()).ToArray());
    }
}