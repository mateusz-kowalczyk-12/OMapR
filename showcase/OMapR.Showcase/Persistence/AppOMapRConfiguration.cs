﻿using OMapR.Api;
using OMapR.Showcase.Entities;

namespace OMapR.Showcase.Persistence;

public static class AppOMapRConfiguration
{
    public static void ConfigureMapping(MappingConfigurator mappingConfigurator)
    {
        mappingConfigurator
            .AddEntityMapping<Teacher>()
            .SetTableName("TEACHERS")
            .SetPrimaryKey(teacher => teacher.Number)
            .MapProperty(teacher => teacher.Number, "TNO")
            .MapProperty(teacher => teacher.Name, "TNAME")
            .MapProperty(teacher => teacher.Title, "TITLE")
            .MapProperty(teacher => teacher.City, "CITY");

        mappingConfigurator
            .AddEntityMapping<Student>()
            .SetTableName("STUDENTS")
            .SetPrimaryKey(student => student.Number)
            .MapProperty(student => student.Number, "SNO")
            .MapProperty(student => student.Name, "SNAME")
            .MapProperty(student => student.Year, "SYEAR")
            .MapProperty(student => student.City, "CITY");
    }
}